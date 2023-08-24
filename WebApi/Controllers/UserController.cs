using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Hotel.API.Controllers
{
    /*
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {

        [HttpPost("register")]
        public async Task<ActionResult> RegisterUserAsync([FromBody] User modelUser)
        {
            
        }
        [HttpPost("login")]
        public async Task<ActionResult> LoginUserAsync([FromBody] LoginUser modelUser)
        {
            var dto = _mapper.Map<UserDto>(modelUser);
            return Ok(await _userServices.LoginUserAsync(dto));
        }

        [Authorize]
        [HttpGet("me")]
        public async Task<ActionResult> GetMe()
        {
            var viewModel = new UserModel();
            viewModel.Value = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Value).Value;
            viewModel.UserId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            viewModel.Role = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value;
            viewModel.Email = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;
            return Ok(viewModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("GetUsers")]
        public async Task<ActionResult> GetUsersAsync()
        {
            var users = await _userServices.GetUsers();
            var result = _mapper.Map<List<UserModel>>(users);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("SetRole")]
        public async Task<ActionResult> SetRoleAsync([FromBody] SetRoleModel modelUser)
        {
            await _userServices.SetRoleAsync(modelUser.UserId, modelUser.RoleName);
            return Ok();
        }
    }
    */
}
