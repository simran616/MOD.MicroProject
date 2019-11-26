using MOD.DtoLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MOD.ModelLibrary;

namespace MOD.MentorLibrary.Repositories
{
    public class MentorRepository : IMentorRepository
    {

        MentorContext context;
        public MentorRepository(MentorContext context)
        {
            this.context = context;
        }

        public bool AddSkill(int courseId, SetAvailableCoursesDto mentordetails)
        {
            try
            {
                var course = context.Courses.Where(c => c.Id == courseId).SingleOrDefault();
                var ifExists = context.AvailableCourses.Where(ac =>
                        ac.MentorEmail == mentordetails.Email && ac.CourseDetails == course).SingleOrDefault();
                if(ifExists == null)
                {
                    var skill = new AvailableCourses
                    {
                        CourseDetails = course,
                        MentorFname = mentordetails.FName,
                        MentorLname = mentordetails.LName,
                        MentorEmail = mentordetails.Email
                    };
                    context.AvailableCourses.Add(skill);
                    var result = context.SaveChanges();
                    if (result > 0)
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public MentorDto mentorProfileDetails(string email)
        {
            var result = from a in context.MODUsers
                         where a.Email == email
                         select new MentorDto
                         {
                             id = a.Id,
                             Email = a.Email,
                             FName = a.Fname,
                             LName = a.Lname,
                             Active = a.Active
                         };
            return result.SingleOrDefault();
        }

        public IEnumerable<Courses> GetMentorCourses(string email)
        {
            try
            {
                var result1 = from rc in context.AvailableCourses
                              where rc.MentorEmail == email
                              select rc;
                var result =
                    from c in context.Courses
                    where !(from rc in result1
                            select rc.CourseDetails.Id)
                           .Contains(c.Id)
                    select c;
                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }


        public IEnumerable<MentorNotificationDto> GetMentorNotifications(string email)
        {
            try
            {
                var result = from ec in context.EnrolledCourses
                             where email == ec.AvailableCourses.MentorEmail
                             select ec;


                var result1 = from ec in result
                              where ec.CourseStatus == CourseStatus.Requested
                              select ec;


                var result2 = from ec in result1
                              select new MentorNotificationDto
                              {
                                  StudentFname = ec.StudentFname,
                                  StudentLname = ec.StudentLname,
                                  CName = ec.AvailableCourses.CourseDetails.CName,
                                  Id = ec.Id
                              };
                return result2;


            }


            catch (Exception)
            {

                throw;
            }
        }

        IEnumerable<CourseDto> IMentorRepository.MentorSkills(string email)
        {
            try
            {
                var result = from ac in context.AvailableCourses
                             where email == ac.MentorEmail
                             select ac;

                var result1 = from c in context.Courses
                              where (from ac in result
                                     select ac.CourseDetails.Id)
                                     .Contains(c.Id)
                              select new CourseDto
                              {
                                  CName = c.CName,
                                  CDuration = c.CDuration,
                                  CFees = c.CFees,
                              };

                return result1;


            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<StudentNotificationDto> AcceptRequestedCourse(int id)
        {
            var enrolledCourse = context.EnrolledCourses.Find(id);
            enrolledCourse.CourseStatus = CourseStatus.accept;

            var result = from ec in context.EnrolledCourses
                         where id == ec.Id
                         select ec;
            
            var result1 = from ac in context.AvailableCourses
                          where (from ec in result
                                 select ec.AvailableCourses.Id)
                                .Contains(ac.Id)
                          select new StudentNotificationDto
                          {
                              MentorEmail=ac.MentorEmail,
                              MentorFname=ac.MentorFname,
                              MentorLname=ac.MentorLname,
                              CName=ac.CourseDetails.CName

                          };
            int result2 = context.SaveChanges();

            return result1;
        }

        public IEnumerable<StudentNotificationDto> RejectRequestedCourse(int id)
        {
            var enrolledCourse = context.EnrolledCourses.Find(id);
            enrolledCourse.CourseStatus = CourseStatus.decline;
            var result = from ec in context.EnrolledCourses
                         where id == ec.Id
                         select ec;

            var result1 = from ac in context.AvailableCourses
                          where (from ec in result
                                 select ec.AvailableCourses.Id)
                                .Contains(ac.Id)
                          select new StudentNotificationDto
                          {
                              MentorEmail = ac.MentorEmail,
                              MentorFname = ac.MentorFname,
                              MentorLname = ac.MentorLname,
                              CName = ac.CourseDetails.CName

                          };
            int result2 = context.SaveChanges();

            return result1;
        }

        public IEnumerable<MentorEnrolledCoursesDto> GetMentorEnrolledCourses(string email)
        {
            try
            {
                var result = from ec in context.EnrolledCourses
                             where email == ec.AvailableCourses.MentorEmail
                             select ec;

                var result1 = from ec in result
                              where ec.CourseStatus == CourseStatus.paymentdone || ec.CourseStatus == CourseStatus.coursecomplete
                              select ec;

                var enrolledcourses = from ec in result1
                                      select new MentorEnrolledCoursesDto
                                      {
                                          CName = ec.AvailableCourses.CourseDetails.CName,
                                          CFees = ec.AvailableCourses.CourseDetails.CFees,
                                          CDuration = ec.AvailableCourses.CourseDetails.CDuration,
                                          StudentFname = ec.StudentFname,
                                          StudentLname = ec.StudentLname

                                      };

                return enrolledcourses;


            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
