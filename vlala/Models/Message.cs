using MotherHood.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MotherHood.Models
{
    public class Message
    {
        public string Uzenet  { get; set; }
        public string Tema { get; set; }
        public int Id { get; set; }
        public string Cim { get; set; }

        [ForeignKey("ApplicationUser")]
        public string Szerzo { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }


}
