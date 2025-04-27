using BugTicketingSystem.BL;
using BugTicketingSystem.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bug_Tecketing_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BugsController : ControllerBase
    {
        private readonly IBugManager _bugManager;

        public BugsController(IBugManager bugManager)
        {
            _bugManager = bugManager;
        }

        [HttpGet]
        public async Task<ActionResult<List<BugReadDTO>>> GetAll()
        {
            var bug = await _bugManager.GetAllAsync();
            if (bug is null)
            {
                return NotFound();
            }
            return Ok(bug);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BugReadDTO>> GetByID(Guid id)
        {
            var bug = await _bugManager.GetBugByIDAsync(id);
            if (bug is null)
            {
                return NotFound();
            }
            return Ok(bug);
        }

        [HttpPost]
        public async Task<ActionResult> Add(BugAddDTO bug)
        {
            var res = await _bugManager.AddAsync(bug);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }
    }
}
