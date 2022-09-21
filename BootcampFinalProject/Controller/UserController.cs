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

        //The method by which users are registered
        [HttpPost("register")]
        public IActionResult Register(UserDto model)
        {
            userService.Register(model);              
            return Ok(new { message = "Registration successful, please check your email for verification instructions" });
        }

        //method of user login
        [HttpPost("Login")]
        public BaseResponse<TokenResponse> Login([FromBody] TokenRequest request)
        {
            var response = tokenService.GenerateToken(request);
            return response;
        }

        //the part where user data can be updated
        [HttpPut]
        public IActionResult Update(int id, UserDto model)
        {
            userService.Update(id, model);
            return Ok(new { message = "User updated successfully" });
        }

        //user deleted part
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            userService.Remove(id);
            return Ok(new { message = "User deleted successfully" });
        }

    }
}
