using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotherHood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotherHood.Controllers
{
    public class TemaController : Controller
    {
        // GET: TemaController
        public ActionResult Index()
        {
            return View(Enum.GetValues(typeof(Tema)));
        }

        // GET: TemaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }



        
      

       

    }    
}
