using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MotherHood.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            ApplicationDbContext database = new ApplicationDbContext(serviceProvider
                .GetRequiredService<DbContextOptions<ApplicationDbContext>>());

            if(!database.Megye.Any())
            {

                var megyek = File.ReadAllLines(@"Data\megyek.csv").Skip(1);
                database.Database.OpenConnection();
                database.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Megye] ON;");
                foreach (var line in megyek)
                {
                    
                    string[] splitline = line.Split(';');
                    database.Megye.Add(new Models.Megye {Id=int.Parse(splitline[0]), Nev = splitline[1] });
                }
                database.SaveChanges();
                database.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Megye] OFF;");
            }

            if (!database.Users.Any())
            {

                var lines = File.ReadAllLines(@"Data\users.csv").Skip(1);
                database.Database.OpenConnection();
                foreach (var line in lines)
                {
                    string[] splitline = line.Split(';');
                    database.Users.Add(new Models.ApplicationUser {Id=splitline[0], Email= splitline[1], UserName = splitline[1], firstName = splitline[2], lastName = splitline[3], MegyeId = int.Parse(splitline[4]), SzuletesiEv = DateTime.Parse(splitline[5]) });
                }
                database.SaveChanges();
            }

            if (!database.Message.Any())
            {

                var lines = File.ReadAllLines(@"Data\message.csv").Skip(1);
                database.Database.OpenConnection();
                database.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Message] ON;");
                foreach (var line in lines)
                {
                    string[] splitline = line.Split(';');
                    database.Message.Add(new Models.Message { Id = int.Parse(splitline[0]), Uzenet = splitline[1], Tema = (Models.Tema)int.Parse(splitline[2]), Szerzo = splitline[3], Cim = splitline[4] });
                }
                database.SaveChanges();
                database.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Message] OFF;");
            }

            if (!database.Comment.Any())
            {

                var lines = File.ReadAllLines(@"Data\comment.csv").Skip(1);
                database.Database.OpenConnection();
                database.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Comment] ON;");
                foreach (var line in lines)
                {
                    string[] splitline = line.Split(';');
                    database.Comment.Add(new Models.Comment { Id = int.Parse(splitline[0]), Szoveg = splitline[1], Kuldo = splitline[2], Idopont = DateTime.Parse(splitline[3]), MessageId = int.Parse(splitline[4]) });
                }
                database.SaveChanges();
                database.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Comment] OFF;");
            }
        }
    }
}
