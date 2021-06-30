using System.Linq;
using System.Threading.Tasks;
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
    }
}