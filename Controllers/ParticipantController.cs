using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using tuontaAPI.DTO;
using tuontaAPI.Interfaces;
using tuontaAPI.Models;
using System.Collections.Generic;

namespace tuontaAPI.Controllers
{
    [Route("api/participants")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        private readonly IParticipantService _participantService;

        public ParticipantController(IParticipantService participantService)
        {
            _participantService = participantService;
        }

        [HttpGet]
        public ActionResult<List<Participant>> GetParticipants()
        {
            return Ok(_participantService.GetParticipants());
        }

        [HttpGet("user_id/{id}")]
        public ActionResult<Participant> GetParticipantByUserId(int id)
        {
            var participant = _participantService.GetParticipantByUserId(id);
            if (participant == null)
            {
                return NotFound();
            }
            return Ok(participant);
        }

        [HttpGet("{id}")]
        public ActionResult<Participant> GetParticipantById(int id)
        {
            var participant = _participantService.GetParticipantById(id);
            if (participant == null)
            {
                return NotFound();
            }
            return Ok(participant);
        }
    }
}