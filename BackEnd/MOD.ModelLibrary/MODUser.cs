using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MOD.ModelLibrary
{
    public class MODUser : IdentityUser
    {
        public string Fname { get; set; }

        
        public string Lname { get; set; }

        public bool Active { get; set; } = true;

        public DateTime DOB { get; set; }

        public string Skills { get; set; }

        public string Experience { get; set; }



    }
}
