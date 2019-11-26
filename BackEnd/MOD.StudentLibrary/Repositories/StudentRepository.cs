using MOD.DtoLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MOD.ModelLibrary;

namespace MOD.StudentLibrary.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        StudentContext context;
        public StudentRepository(StudentContext context)
        {
            this.context = context;
        }

        public MentorDto studentProfileDetails(string email)
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

        public bool EnrolledByStudent(int availablecourseid, EnrolledStudentDto studentdetails)
        {

            try
            {
                var availablecoursesdetails = (from ac in context.AvailableCourses
                                               where availablecourseid == ac.Id
                                               select ac).SingleOrDefault();


                //var ifexists = from ac in context.AvailableCourses
                //               where ac.CourseDetails == coursesdetails && ac.MentorEmail == mentordetails.Email
                //               select ac;

                //if (ifexists == null)
                //{
                context.EnrolledCourses.Add(new EnrolledCourses
                {
                    AvailableCourses = availablecoursesdetails,
                    StudentEmail = studentdetails.Email,
                    StudentFname = studentdetails.Fname,
                    StudentLname = studentdetails.Lname,
                    CourseStatus =CourseStatus.Requested

                });
                var result = context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                return false;
                //}

                //return false;

            }
            catch (Exception e)
            {

                throw;
            }
        }

        public IEnumerable<AvailableStudentCourseDto> StudentAvailableCourses(string email)
        {
            var result1 = from ec in context.EnrolledCourses
                          where ec.StudentEmail == email
                          select ec;


            var result = from ac in context.AvailableCourses
                         where !(from ec in result1
                                 select ec.AvailableCourses.Id)
                                .Contains(ac.Id)
                         select new AvailableStudentCourseDto
                         {
                             MentorFname = ac.MentorFname,
                             MentorLname = ac.MentorLname,
                             MentorEmail = ac.MentorEmail,
                             CName = ac.CourseDetails.CName,
                             CDuration = ac.CourseDetails.CDuration,
                             CFees = ac.CourseDetails.CFees,
                             Id = ac.Id
                         };
            return result;

        }

        public IEnumerable<StudentNotificationDto> GetStudentNotifications(string email)
        {
            try
            {
                var result = from ec in context.EnrolledCourses
                             where email == ec.StudentEmail
                             select ec;


                var result1 = from ec in result
                              where ec.CourseStatus == CourseStatus.accept || ec.CourseStatus ==CourseStatus.decline
                              select ec;


                var result2 = from ec in result1
                              select new StudentNotificationDto
                              {
                                  MentorFname = ec.AvailableCourses.MentorFname,
                                  MentorLname = ec.AvailableCourses.MentorLname,
                                  CName = ec.AvailableCourses.CourseDetails.CName,
                                  Id = ec.Id,
                                  CourseStatus = ec.CourseStatus
                                  
                              };
                return result2;


            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<StudentEnrolledCoursesDto> GetStudentEnrolledCourses(string email)
        {
            try
            {
                var result = from ec in context.EnrolledCourses
                             where email == ec.StudentEmail 
                                && (ec.CourseStatus == CourseStatus.paymentdone || ec.CourseStatus == CourseStatus.coursecomplete)
                             select ec;

                var enrolledcourses = from ec in result
                                      select new StudentEnrolledCoursesDto
                                      {
                                          CName = ec.AvailableCourses.CourseDetails.CName,
                                          CDuration = ec.AvailableCourses.CourseDetails.CDuration,
                                          CFees = ec.AvailableCourses.CourseDetails.CFees,
                                          MentorFname = ec.AvailableCourses.MentorFname,
                                          MentorLname = ec.AvailableCourses.MentorLname,
                                          CourseStatus = ec.CourseStatus,
                                          Id = ec.Id
                                      };

                return enrolledcourses;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool PayNow(int id)
        {
            try
            {
                var response = context.EnrolledCourses.Where(ec => ec.Id == id).FirstOrDefault();
                response.CourseStatus = CourseStatus.paymentdone;
                context.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool CompletedCourse(int id)
        {
            try
            {
                var response = (from ec in context.EnrolledCourses
                               where id == ec.Id
                               select ec).SingleOrDefault();
                if(response.CourseStatus == CourseStatus.paymentdone)
                {
                    response.CourseStatus = CourseStatus.coursecomplete;
                    var result = context.SaveChanges();
                    if (result > 0)
                    {
                        return true;
                    }
                    return false;
                }
                return false;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
