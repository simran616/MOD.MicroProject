using System;
using System.Collections.Generic;
using System.Text;

namespace MOD.ModelLibrary
{
    public class EnrolledCourses
    {
        public int Id { get; set; }
        public AvailableCourses AvailableCourses { get; set; }
        public string StudentFname { get; set; }
        public string StudentLname { get; set; }
        public string StudentEmail { get; set; }

        public CourseStatus CourseStatus { get; set; }

    }
}
