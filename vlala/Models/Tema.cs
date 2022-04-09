using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MotherHood.Models
{
    public enum Tema
    {
        Orvos,
        [Display(Name = "Társkereső")]
        Tarskereso,
        Babysitter,
        [Display(Name = "Óvoda")]
        Ovoda,
        Iskola,
    }
}
