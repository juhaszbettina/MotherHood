using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MotherHood.Models
{
    public class UsersSearchViewModel
    {
        public string keresNev { get; set; }

        public int keresMegye { get; set; }


        public List<ApplicationUser> applicationUsers { get; set; }
        public List<SelectListItem> Megye { get; set; }
     }
 }
