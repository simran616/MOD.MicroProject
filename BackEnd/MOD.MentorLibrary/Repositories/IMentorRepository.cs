using MOD.DtoLibrary;
using MOD.ModelLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOD.MentorLibrary.Repositories
{
    public interface IMentorRepository
    {
        public MentorDto mentorProfileDetails(string email);
        public bool AddSkill(int courseId, SetAvailableCoursesDto mentordetails);
        IEnumerable<Courses> GetMentorCourses(string email);
        IEnumerable<CourseDto> MentorSkills(string email);
        IEnumerable<MentorNotificationDto> GetMentorNotifications(string email);
        IEnumerable<StudentNotificationDto> AcceptRequestedCourse(int id);
        IEnumerable<StudentNotificationDto> RejectRequestedCourse(int id);
        IEnumerable<MentorEnrolledCoursesDto> GetMentorEnrolledCourses(string email);
    }
}
