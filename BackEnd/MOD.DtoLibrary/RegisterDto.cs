using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MOD.DtoLibrary
{
    public class RegisterDto
    {

        [Required]
        public string Fname { get; set; }

        [Required]
        public string Lname { get; set; }


        [Required]
        //[EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "PASSWORD_MIN_LENGTH", MinimumLength = 6)]
        public string Password { get; set; }

        public string Role { get; set; }
    }
}
