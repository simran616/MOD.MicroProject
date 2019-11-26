using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MOD.AdminLibrary.Repositories;
using MOD.ModelLibrary;

namespace MOD.AdminService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AdminController : ControllerBase
    {
        IAdminRepository repository;
        public AdminController(IAdminRepository repository)
        {
            this.repository = repository;
        }



        // GET: api/Admin
        [HttpGet]
        public IActionResult GetCourses()
        {
            var courses = repository.GetCourses();
            if (!courses.Any())
            {
                return NoContent();
            }
            return Ok(courses);
        }



        // GET: api/Admin/5
        [HttpGet("{id}", Name = "GetCourseById")]
        public IActionResult GetCourseById(int Id)
        {
            var course = repository.GetCourseById(Id);

            return Ok(course);
        }


        [HttpGet("mentorsList")]
        public IActionResult GetMentorsList()
        {
            return Ok(repository.GetMentorsList());
        }



        [HttpGet("studentsList")]
        public IActionResult GetStudentsList()
        {
            return Ok(repository.GetStudentsList());
        }



        [HttpGet("admindetails")]
        public IActionResult GetAdminDetails()
        {
            return Ok(repository.GetAdminDetails());
        }



        [HttpGet("blockunblock/{id}")]
        public IActionResult GetBlockUnblock(string id)
        {
            var result = repository.BlockUser(id);
            if (result)
            {
                return Ok();
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }



        // POST: api/Admin
        [HttpPost]
        public IActionResult Post([FromBody] Courses course)
        {
            if (ModelState.IsValid)
            {
                bool result = repository.AddCourse(course);
                if (result)
                {
                    return Created("AddCourse", course.Id);
                }
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return BadRequest(ModelState);

        }




        // PUT: api/Admin/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]  Courses course)
        {
            if (ModelState.IsValid && id == course.Id)
            {
                bool result = repository.UpdateCourse(course);
                if (result)
                {
                    return Ok();
                }
                return StatusCode(StatusCodes.Status500InternalServerError);

            }
            return BadRequest(ModelState);
        }





        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var course = repository.GetCourseById(id);
            if (course == null)
            {
                return NotFound();
            }
            bool result = repository.DeleteCourse(course);
            if (result)
            {
                return Ok();
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}