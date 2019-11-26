using MOD.ModelLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOD.DtoLibrary
{
    public class SetAvailableCoursesDto
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public Courses CourseDetails { get; set; }
    }
}
