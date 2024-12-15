using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using tuontaAPI.DTO;
using tuontaAPI.Interfaces;

namespace tuontaAPI.Controllers
{

    [Route("api/match")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IMatchService _matchService;

        public MatchController(IMatchService matchservice)
        {
            _matchService = matchservice;
        }

        [HttpGet]
        public ActionResult<List<MatchedItemDto>> GetAllMatches()
        {
            return Ok(_matchService.GetMatches());
        }

        [HttpGet("matches/")]
        public ActionResult<List<MatchStatusDto>> GetAllMatchStatus()
        {
            return Ok(_matchService.GetAllMatchStatus());
        }

        [HttpGet("matches/{userId}")]
        public ActionResult<List<MatchedItemDto>> GetMatchedByUser(int userId)
        {
            return Ok(_matchService.GetAllMatchedItemByUserId(userId));
        }

        [HttpGet("{userId}")]
        public ActionResult<List<MatchedItemDto>> GetMatchStatusByUser(int userId)
        {
            return Ok(_matchService.GetAllMatchStatusByUserId(userId));
        }

        [HttpPost("send/")]
        public IActionResult SendMatchRequest(MatchStatusDto matchStatus)
        {
            bool res = _matchService.CreateMatchStatus(matchStatus);

            if (res)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateMatchRequest(int id, ChatItemDto chatItemDto)
        {
            var res = _matchService.UpdateMatchStatus(id, chatItemDto);

            if(res == null)
            {
                return BadRequest();
            } else
            {
                return Ok(res);
            }
        }

        [HttpGet("users/{id}")]
        public IActionResult GetUsersOfMatchStatus(int id)
        {
            return Ok(_matchService.GetUsersOfMatchedItem(id));
        }
    }
}


