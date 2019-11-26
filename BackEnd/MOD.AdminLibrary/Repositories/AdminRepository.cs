using MOD.DtoLibrary;
using MOD.ModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MOD.AdminLibrary.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        AdminContext context;
        public AdminRepository(AdminContext context)
        {
            this.context = context;
        }

        //Add courses by admin
        public bool AddCourse(Courses course)
        {
            try
            {
                context.Courses.Add(course);
                int result = context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        //view courses
        public IEnumerable<Courses> GetCourses()
        {
            return context.Courses.ToList();
        }


        //view course by id
        public Courses GetCourseById(int Id)
        {
            return context.Courses.Find(Id);
        }


        //update course
        public bool UpdateCourse(Courses course)
        {
            try
            {
                context.Courses.Update(course);
                int result = context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteCourse(Courses course)
        {

            try
            {
                context.Courses.Remove(course);
                int result = context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public IEnumerable<MentorDto> GetMentorsList()
        {
            var mentor = from a in context.MODUsers
                         join ma in context.UserRoles on a.Id equals ma.UserId
                         where ma.RoleId == "2"
                         select new MentorDto
                         {
                             id = a.Id,
                             FName = a.Fname,
                             LName = a.Lname,
                             Email = a.Email,
                             Active = a.Active

                         };
            return mentor;
        }


        public IEnumerable<MentorDto> GetStudentsList()
        {
            var students = from a in context.MODUsers
                           join ma in context.UserRoles on a.Id equals ma.UserId
                           where ma.RoleId == "3"
                           select new MentorDto
                           {
                               id = a.Id,
                               FName = a.Fname,
                               LName = a.Lname,
                               Email = a.Email,
                               Active = a.Active

                           };
            return students;
        }

        public IEnumerable<MentorDto> GetAdminDetails()
        {
            var admin = from a in context.MODUsers
                        join ma in context.UserRoles on a.Id equals ma.UserId
                        where ma.RoleId == "1"
                        select new MentorDto
                        {
                            id = a.Id,
                            FName = a.Fname,
                            LName = a.Lname,
                            Email = a.Email


                        };
            return admin;
        }

        public bool BlockUser(string id)
        {
            {
                var userblock = context.MODUsers.SingleOrDefault(u => u.Id == id);
                userblock.Active = !userblock.Active;
            }
            var result = context.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            return false;
        }
    }
}
