using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MotherHood.Models;
using Microsoft.AspNetCore.Authorization;
using MotherHood.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MotherHood.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, 
            ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [Authorize]
        public async Task<IActionResult> Index(int? keresMegye, string keresNev)
        {
            var felhasznalok = _context.Users.Select(x => x);

            if (keresMegye != null)
            {
                felhasznalok = felhasznalok.Include(user => user.Megye).Where(felhasznalo => felhasznalo.Megye.Id == keresMegye);
            }

            if (!string.IsNullOrEmpty(keresNev))
            {
                felhasznalok = felhasznalok.Include(user => user.Megye).Where(felhasznalo => felhasznalo.firstName.Contains(keresNev) || felhasznalo.lastName.Contains(keresNev));
            }

            List<Megye> megyelista = _context.Megye.ToList();

            UsersSearchViewModel modelkereseshez = new UsersSearchViewModel();
            modelkereseshez.Megye = megyelista.Select(x => new SelectListItem() { Text = x.Nev, Value = x.Id.ToString() }).ToList();
            modelkereseshez.keresNev = keresNev;
            modelkereseshez.applicationUsers = await felhasznalok.ToListAsync();




            return View(modelkereseshez);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
