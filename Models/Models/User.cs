﻿using Microsoft.AspNetCore.Identity;

namespace Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
    }
}
