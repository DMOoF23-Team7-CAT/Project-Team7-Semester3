using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Rally.Models;

namespace Rally.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }


        [Route("User")]
        public IActionResult Index()
        {
            return View();
        }

        // GET: api/user
        [HttpGet]
        public IActionResult Get()
        {
            // TODO: Implement logic to retrieve all users
            return Ok("Get all users");
        }

        // GET: api/user/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            // TODO: Implement logic to retrieve a specific user by id
            return Ok($"Get user with id {id}");
        }

        // POST: api/user
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            // TODO: Implement logic to create a new user
            return Ok("Create a new user");
        }

        // PUT: api/user/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            // TODO: Implement logic to update an existing user
            return Ok($"Update user with id {id}");
        }

        // DELETE: api/user/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // TODO: Implement logic to delete a user by id
            return Ok($"Delete user with id {id}");
        }
    }

    public class User
    {
        // TODO: Add properties for user data
    }
}
