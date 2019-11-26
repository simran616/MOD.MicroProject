using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MOD.ModelLibrary
{
    public class Courses
    {
        [Key]
        public int Id { get; set; }
        public string CName { get; set; }
        public string CDuration { get; set; }
        public int CFees { get; set; }

    }
}
