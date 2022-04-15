using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using MotherHood.Models;

namespace MotherHood.Data
{
    public class ApplicationDbContext : IdentityDbContext< ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
     protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
                .Property(e => e.firstName)
                .HasMaxLength(250);

            modelBuilder.Entity<ApplicationUser>()
                .Property(e => e.lastName)
                .HasMaxLength(250);

        }
     public DbSet<MotherHood.Models.Message> Message { get; set; }
     public DbSet<MotherHood.Models.Comment> Comment { get; set; }
     public DbSet<MotherHood.Models.Megye> Megye { get; set; }

    }
}
