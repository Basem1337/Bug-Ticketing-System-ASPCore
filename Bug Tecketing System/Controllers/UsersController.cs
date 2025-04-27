using BugTicketingSystem.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bug_Tecketing_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserManager _userManager;

        public UsersController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserReadDTO>>> GetAll()
        {
            var users = await _userManager.GetAllAsync();
            if (users is null)
            {
                return NotFound();
            }
            return Ok(users);
        }

        [HttpPost("register")]
        public async Task<ActionResult> Add(UserRegisterDTO user)
        {
            var res = await _userManager.AddAsync(user);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        //[HttpPost("login")]
        //public async Task<ActionResult> Add(UserLoginInfo user)
        //{
            
        //}

    }
}
