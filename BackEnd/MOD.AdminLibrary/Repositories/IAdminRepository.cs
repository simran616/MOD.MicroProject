using MOD.DtoLibrary;
using MOD.ModelLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOD.AdminLibrary.Repositories
{
    public interface IAdminRepository
    {
        bool AddCourse(Courses course);
        IEnumerable<Courses> GetCourses();

        bool UpdateCourse(Courses course);
        Courses GetCourseById(int Id);
        bool DeleteCourse(Courses course);
        IEnumerable<MentorDto> GetMentorsList();
        IEnumerable<MentorDto> GetStudentsList();
        IEnumerable<MentorDto> GetAdminDetails();
        bool BlockUser(string id);
    }
}
