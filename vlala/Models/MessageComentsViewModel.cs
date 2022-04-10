using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MotherHood.Models
{
    public class MessageComentsViewModel
    {
        public Message message { get; set; }

        [Display(Name="Hozzászólás")]
        public string Szoveg { get; set; }
        public int MessageId { get; set; }

    }
}
