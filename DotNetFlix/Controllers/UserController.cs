using DotNetFlix.Dto.User;
using DotNetFlix.Services.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DotNetFlix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) 
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersAsync() 
        {
            var users = await  _userService.GetUsersAsync();
            
            return Ok(users);
        }
        [HttpGet("UserById")]
        public async Task<IActionResult> GetUserById(int id) 
        {
            var user = await _userService.GetUserById(id);
            return Ok(user);
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(CreateUserDto userDto)
        {
            var user = await _userService.CreateUser(userDto);
            return Ok(user);
        }

        [HttpDelete("DeleteUser{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userService.DeleteUser(id);
            return Ok(user);
        }
        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(ShowUserDto userdto)
        {
            var user =await  _userService.UpdateUser(userdto);
            return Ok(user);
        }
    }
}
