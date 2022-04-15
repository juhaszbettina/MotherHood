using Microsoft.AspNetCore.Identity;
using MotherHood.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MotherHood.Data
{
    public class ApplicationUser : IdentityUser

    {
        public string firstName { get; set; }
        public string lastName { get; set; }

        public DateTime SzuletesiEv { get; set; }

        [ForeignKey("Megye")]
        public int? MegyeId { get; set; }
        public Megye Megye { get; set; }

    }
}
