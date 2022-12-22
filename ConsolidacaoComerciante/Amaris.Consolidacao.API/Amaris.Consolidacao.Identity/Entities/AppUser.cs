﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amaris.Consolidacao.Identity.Entities
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; } = string.Empty;
    }
}
