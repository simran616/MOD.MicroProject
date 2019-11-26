using MOD.ModelLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOD.DtoLibrary
{
    public class StudentEnrolledCoursesDto
    {
        public string CName { get; set; }
        public string CDuration { get; set; }
        public int CFees { get; set; }
        public string MentorFname { get; set; }
        public string MentorLname { get; set; }
        public CourseStatus CourseStatus { get; set; }
        public int Id { get; set; }

    }
}
