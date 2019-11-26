using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MOD.UserLibrary.Repositories;

namespace MOD.UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserRepository repository;
        public UserController(IUserRepository repository)
        {
            this.repository = repository;
        }





        // GET: api/User
        [HttpGet]
        public IEnumerable<string> GetUserList()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "GetUser")]
        public string GetUser(int id)
        {
            return "value";
        }


        [HttpGet("search/{criteria}")]
        public IActionResult SearchCourse(string criteria)
        {
            var result = repository.SearchCourse(criteria);
            return Ok(result);
        }

        // POST: api/User
        [HttpPost]
        public void PostUser([FromBody] string value)
        {
        }




        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }



        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void DeleteUser(int id)
        {
        }
    }
}