using Microsoft.AspNetCore.Identity;
using MotherHood.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MotherHood.Models
{
    public class ApplicationUser : IdentityUser

    {
        public string firstName { get; set; }
        public string lastName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime SzuletesiEv { get; set; }

        [ForeignKey("Megye")]
        public int? MegyeId { get; set; }
        public Megye Megye { get; set; }

    }
}
