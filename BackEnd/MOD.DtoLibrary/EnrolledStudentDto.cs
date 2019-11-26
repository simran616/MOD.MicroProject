using MOD.ModelLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOD.DtoLibrary
{
    public class EnrolledStudentDto
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public AvailableCourses AvailableCourses { get; set; }

    }
}
