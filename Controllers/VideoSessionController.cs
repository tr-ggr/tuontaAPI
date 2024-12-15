using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using tuontaAPI.DTO;
using tuontaAPI.Interfaces;
using tuontaAPI.Models;
using System.Collections.Generic;

namespace tuontaAPI.Controllers
{
    [Route("api/videosessions")]
    [ApiController]
    public class VideoSessionController : ControllerBase
    {
        private readonly IVideoSessionService _videoSessionService;

        public VideoSessionController(IVideoSessionService videoSessionService)
        {
            _videoSessionService = videoSessionService;
        }

        [HttpGet]
        public IActionResult GetVideoSessions()
        {
            return Ok(_videoSessionService.GetVideoSessions());
        }

        [HttpGet("user_id/{id}")]
        public IActionResult GetVideoSessionByUserId(int id)
        {
            var videoSession = _videoSessionService.GetVideoSessionByUserId(id);
            if (videoSession == null)
            {
                return NotFound();
            }
            return Ok(videoSession);
        }

        [HttpGet("{id}")]
        public IActionResult GetVideoSessionById(int id)
        {
            var videoSession = _videoSessionService.GetVideoSessionById(id);
            if (videoSession == null)
            {
                return NotFound();
            }
            return Ok(videoSession);
        }

        [HttpPost]
        public IActionResult AddVideoSession([FromBody] VideoSession videoSession)
        {
            if (videoSession == null)
            {
                return BadRequest();
            }

            int newVideoSessionId = _videoSessionService.AddVideoSession(videoSession);
            return Ok(newVideoSessionId);
        }
    }
}