using MotherHood.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MotherHood.Models
{
    public class Message
    {
        [Display(Name = "Üzenet")]
        public string Uzenet  { get; set; }

        [Display(Name = "Téma")]
        public virtual Tema Tema { get; set; }
       
        public int Id { get; set; }

        [Display(Name = "Cím")]
        public string Cim { get; set; }

        
        [ForeignKey("ApplicationUser")]
        public string Szerzo { get; set; }

        public virtual List<Comment> Comment { get; set; }

        [Display(Name = "Szerző")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }


}
