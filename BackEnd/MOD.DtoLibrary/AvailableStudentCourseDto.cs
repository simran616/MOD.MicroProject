using System;
using System.Collections.Generic;
using System.Text;

namespace MOD.DtoLibrary
{
    public class AvailableStudentCourseDto
    {
        public int Id { get; set; }
        public string MentorFname { get; set; }
        public string MentorLname { get; set; }
        public string MentorEmail { get; set; }
        public string CName { get; set; }
        public string CDuration { get; set; }
        public int CFees { get; set; }
    }
}
