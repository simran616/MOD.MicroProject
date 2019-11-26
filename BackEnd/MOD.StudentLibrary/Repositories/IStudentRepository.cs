using MOD.DtoLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOD.StudentLibrary.Repositories
{
    public interface IStudentRepository
    {
        MentorDto studentProfileDetails(string email);
        bool EnrolledByStudent(int availablecourseid, EnrolledStudentDto studentdetails);
        IEnumerable<AvailableStudentCourseDto> StudentAvailableCourses(string email);
        IEnumerable<StudentNotificationDto> GetStudentNotifications(string email);
        IEnumerable<StudentEnrolledCoursesDto> GetStudentEnrolledCourses(string email);
        bool PayNow(int id);
        bool CompletedCourse(int id);
    }
}
