using System.Linq;
using System.Threading.Tasks;
using AspNetDDD.Domain;
using AspNetDDD.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace AspNetDDD.API.Controllers
{
    [ApiController]
    [Route("v1/api/")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAll();
            if (users.Any())
            {
                return Ok(users);
            }
            return NotFound();
        }

        [HttpGet("users/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetById(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }

        [HttpPost("users")]
        public async Task<IActionResult> CreateUser(UserViewModel userViewModel)
        {
            var user = await _userService.Create(userViewModel);
            if (user != null)
            {
                return CreatedAtAction(nameof(GetAllUsers), user);
            }
            return NoContent();
        }

        [HttpPut("users")]
        public async Task<IActionResult> UpdateUser(UserViewModel userViewModel)
        {
            var user = await _userService.GetById(userViewModel.Id);
            if (user != null)
            {
                await _userService.Update(userViewModel);
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("users/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userService.GetById(id);
            if (user != null)
            {
                await _userService.Delete(user.Id);
                return NoContent();
            }
            return NotFound();
        }
    }
}