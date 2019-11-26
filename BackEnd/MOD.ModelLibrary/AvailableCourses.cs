using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MOD.ModelLibrary
{
    public class AvailableCourses
    {
        [Key]
        public int Id { get; set; }
       
        public Courses CourseDetails { get; set; }
        
        public string MentorFname { get; set; }
        
        public string MentorLname { get; set; }
        
        public string MentorEmail { get; set; }

    }
}
