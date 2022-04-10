using MotherHood.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MotherHood.Models
{
    public class Comment
    {
        public string Szoveg { get; set; }

        [ForeignKey("ApplicationUser")]
        public string Kuldo { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        [DataType(DataType.Date)]
        public DateTime Idopont { get; set; }
        public int Id { get; set; }


        [ForeignKey("Message")]
        public int MessageId { get; set; }
        public Message Message { get; set; }

   
    }
}
