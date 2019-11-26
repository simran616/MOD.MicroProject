using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MOD.DtoLibrary
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public String Email { get; set; }


        [Required]
        public String Password { get; set; }
    }
}
