using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MOD.DtoLibrary;
using MOD.StudentLibrary.Repositories;

namespace MOD.StudentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentController : ControllerBase
    {

        IStudentRepository repository;
        public StudentController(IStudentRepository repository)
        {
            this.repository = repository;
        }


        // GET: api/Student
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }



        // GET: api/Student/5
        [HttpGet("{id}", Name = "GetStudent")]
        public string GetStudent(int id)
        {
            return "value";
        }


        [HttpGet("studentProfile/{email}")]
        public IActionResult studentProfileDetails(string email)
        {
            var result = repository.studentProfileDetails(email);
            return Ok(result);
        }




        [HttpGet("studentavailablecourse/{email}")]
        public IActionResult StudentAvailableCourses(string email)
        {
            try
            {
                var availablecourses = repository.StudentAvailableCourses(email);
                if (!availablecourses.Any())
                {
                    return NoContent();
                }
                return Ok(availablecourses);

            }
            catch (Exception e)
            {

                throw;
            }
        }



        [HttpPost("enrolledbystudent/{availablecourseid}")]
        public IActionResult EnrolledByStudent(int availablecourseid, [FromBody] EnrolledStudentDto studentdetails)
        {

            try
            {
                bool result = repository.EnrolledByStudent(availablecourseid, studentdetails);
                if (result)
                {
                    return Ok();
                }
                return StatusCode(StatusCodes.Status500InternalServerError);

            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        // POST: api/Student
        [HttpGet("pay/{id}")]
        public IActionResult Pay(int id)
        {
            try
            {
                var response = repository.PayNow(id);
                return Ok(response);
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpGet("getstudentenrolledcourses/{email}")]
        public IActionResult mentorenrolledcourses(string email)
        {
            try
            {
                var result = repository.GetStudentEnrolledCourses(email);
                return Ok(result);

            }
            catch (Exception)
            {

                throw;
            }
        }



        [HttpGet("getnotification/{email}")]
        public IActionResult studentnotification(string email)
        {
            try
            {
                var result = repository.GetStudentNotifications(email);
                return Ok(result);

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("completecourse/{id}")]
        public IActionResult CompletedCourse(int id)
        {
            try
            {
                var response = repository.CompletedCourse(id);
                return Ok(response);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}