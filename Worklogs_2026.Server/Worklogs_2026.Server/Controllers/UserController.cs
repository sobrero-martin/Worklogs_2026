using Microsoft.AspNetCore.Mvc;
using Worklogs_2026.BD.Data.Entities;
using Worklogs_2026.Repositorio.Repository;
using Worklogs_2026.Shared.DTO;

namespace Worklogs_2026.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository repository;

        public UserController(IUserRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginDTO login)
        {
            var res = await repository.Login(login);

            if (res == 0)
                return NotFound("Email doesn't exist or the password is incorrect");
           
            
            return Ok("Login was succesful");
        }



        /*
         
        [HttpGet("byEmail/{email}")]
        public async Task<ActionResult<User>> GetByEmail(string email)
        {
            var user = await repository.GetByEmail(email);
            if (user == null)
            {
                return NotFound($"No user found with email {email}.");
            }
            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetFull()
        {
            var users = await repository.GetFull();

            if (users == null)
            {
                return NotFound("No users found(NULL).");
            }

            if (users.Count == 0)
            {
                return NotFound("No existing users.");
            }

            return Ok(users);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            var user = await repository.GetById(id);
            if (user == null)
            {
                return NotFound($"No user found with ID {id}.");
            }
            return Ok(user);
        }

 

        [HttpPost]
        public async Task<ActionResult<int>> Post(User user)
        {
            try
            {
                await repository.Post(user);
                return Ok(user.Id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, User user)
        {
            var result = await repository.Put(id, user);
            return Ok($"User with id {id} correctly updated");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await repository.Delete(id);
            if (!result)
            {
                return NotFound($"No user found with ID {id} to delete.");
            }
            return Ok($"User with id {id} correctly deleted");
        }

        */
    }
}
