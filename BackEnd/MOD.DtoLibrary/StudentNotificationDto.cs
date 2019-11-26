using MOD.ModelLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOD.DtoLibrary
{
    public class StudentNotificationDto
    {
        public string MentorFname { get; set; }
        public string MentorLname { get; set; }
        public string MentorEmail { get; set; }
        public string CName { get; set; }
        public int Id { get; set; }
        public CourseStatus CourseStatus { get; set; }
    }
}
