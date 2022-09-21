using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using BootcampFinalProject.Service;
using BootcampFinalProject.Models;
using TechaApiHibernate.StartUpExtension;
using Microsoft.AspNetCore.Authorization;
using BootcampFinalProject.Base.Response;
using BootcampFinalProject.Base.Token;
using BootcampFinalProject.Service.Token;

namespace BootcampFinalProject.Controller
{
    [ApiController]
    [Route("[controller]")]

    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly ITokenService tokenService;


        public UserController(IUserService userService, ITokenService tokenService)
        {
            this.userService = userService;
            this.tokenService = tokenService;
        }

        [HttpPost("register")]
        public IActionResult Register(UserDto model)
        {
            userService.Register(model);              
            return Ok(new { message = "Registration successful, please check your email for verification instructions" });
        }

        [HttpPost("Login")]
        public BaseResponse<TokenResponse> Login([FromBody] TokenRequest request)
        {
            var response = tokenService.GenerateToken(request);
            return response;
        }

        [HttpPut]
        public IActionResult Update(int id, UserDto model)
        {
            userService.Update(id, model);
            return Ok(new { message = "User updated successfully" });
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            userService.Remove(id);
            return Ok(new { message = "User deleted successfully" });
        }

    }
}
