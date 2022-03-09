﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotherHood.Data
{
    public class ApplicationUser : IdentityUser

    {
        public string firstName { get; set; }
        public string lastName { get; set; }
    }
}
