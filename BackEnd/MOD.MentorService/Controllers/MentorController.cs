using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MOD.DtoLibrary;
using MOD.MentorLibrary.Repositories;
using MOD.ModelLibrary;

namespace MOD.MentorService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MentorController : ControllerBase
    {
        IMentorRepository repository;
        public MentorController(IMentorRepository repository)
        {
            this.repository = repository;
        }



        // GET: api/Mentor
        [HttpGet("getCourses/{email}")]
        public IActionResult GetMentorCourses(string email)
        {
            var courses = repository.GetMentorCourses(email);
            if (!courses.Any())
            {
                return NoContent();
            }
            return Ok(courses);
        }


        [HttpGet("getskills/{email}")]
        public IActionResult MentorSkills(string email)
        {
            try
            {
                var skills = repository.MentorSkills(email);
                if (!skills.Any())
                {
                    return NoContent();
                }
                return Ok(skills);

            }
            catch (Exception e)
            {

                throw;
            }
        }



        [HttpGet("acceptRequestedCourse/{id}", Name = "AcceptRequestedCourse")]
        public IActionResult AcceptRequestedCourse(int id)
        {
            if (ModelState.IsValid)
            {
                var result = repository.AcceptRequestedCourse(id);
                if (!result.Any())
                {
                    return NoContent();
                }
                return Ok(result);
            }
            return BadRequest(ModelState);
        }



        [HttpGet("rejectRequestedCourse/{id}", Name = "RejectRequestedCourse")]
        public IActionResult RejectRequestedCourse(int id)
        {
            if (ModelState.IsValid)
            {
                var result = repository.RejectRequestedCourse(id);
                if (!result.Any())
                {
                    return NoContent();
                }
                return Ok(result);
            }
            return BadRequest(ModelState);
        }



        [HttpPost("addskills/{courseId}")]
        public IActionResult Addskills(int courseId,[FromBody] SetAvailableCoursesDto mentordetails )
        {
            try
            {
                var result = repository.AddSkill(courseId, mentordetails);
                if(result)
                {
                    return Ok(new { Message = "Skill added successfully." });
                }
                return BadRequest(new { Message = "Internal Server error or Dublicate error." });
            }
            catch (Exception e)
            {
                return BadRequest(new { Message = "Internal Server error" });
            }
        }



        [HttpGet("mentorProfile/{email}")]
        public IActionResult mentorProfileDetails(string email)
        {
            var result = repository.mentorProfileDetails(email);
            return Ok(result);
        }



        [HttpGet("getnotification/{email}")]
        public IActionResult mentornotification(string email)
        {
            try
            {
                var result = repository.GetMentorNotifications(email);
                return Ok(result);

            }
            catch (Exception)
            {

                throw;
            }
        }




        [HttpGet("getmentorenrolledcourses/{email}")]
        public IActionResult mentorenrolledcourses(string email)
        {
            try
            {
                var result = repository.GetMentorEnrolledCourses(email);
                return Ok(result);

            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT: api/Mentor/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }



        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}