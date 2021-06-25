using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetDDD.Domain;
using AspNetDDD.Service;
using Microsoft.AspNetCore.Mvc;

namespace AspNetDDD.API.Controllers
{
    [ApiController]
    [Route("v1/api/")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("users")]
        public Task<IEnumerable<UserViewModel>> GetAllUsers()
        {
            return _userService.GetAll();
        }
    }
}