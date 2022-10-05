using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System;
using System.Linq;
using System.Threading.Tasks;
using CalendarDiary.Backend.Attributes;
using ImplementationServices;
using InterfacesServices;
using InterfacesServices.ApiModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;


namespace CalendarDiary.Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        public UserController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest model) {
            var response = await _userService.Login(model);

            if (response == null)
                return StatusCode(401,"Логин или пароль неверны");
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterUser userModel)
        {
            var response = await _userService.Register(userModel);
            if (response == null)
            {
                return BadRequest(new {message = "Пользователь с таким именем уже существует"});
            }
            return Ok(response);
        }

        [HttpGet("CheckToken/{token}")]
        public async Task<IActionResult> CheckToken(string token)
        {
            var user = await _userService.CheckToken(token);
            if (user != null)
            {
                return Ok(new LoginResponse(user,token));
            }
            else return StatusCode(401, "Токен не валиден");
        }

        [Authorize]
        [HttpGet("getUser/{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetById(id);
            return Ok(user);
        }


    }
}
