using System.Threading.Tasks;
using CalendarDiary.Backend.Attributes;
using InterfacesServices;
using InterfacesServices.ApiModels;
using Microsoft.AspNetCore.Mvc;


namespace CalendarDiary.Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest model)
        {
            var response = await _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterUser userModel)
        {
            var response = await _userService.Register(userModel);
            if (response == null)
            {
                return BadRequest(new {message = "Didn't register!"});
            }
            return Ok(response);
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
