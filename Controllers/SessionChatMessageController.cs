using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using tuontaAPI.DTO;
using tuontaAPI.Interfaces;
using tuontaAPI.Models;
using System.Collections.Generic;

namespace tuontaAPI.Controllers
{
    [Route("api/chatsessionmessages")]
    [ApiController]
    public class ChatSessionMessageController : ControllerBase
    {
        private readonly IChatSessionMessageService _chatSessionMessageService;

        public ChatSessionMessageController(IChatSessionMessageService chatSessionMessageService)
        {
            _chatSessionMessageService = chatSessionMessageService;
        }

        [HttpGet]
        public IActionResult GetChatSessionMessages()
        {
            return Ok(_chatSessionMessageService.GetChatSessionMessages());
        }

        [HttpGet("session_id/{id}")]
        public IActionResult GetChatSessionMessagesBySessionId(int id)
        {
            var messages = _chatSessionMessageService.GetChatSessionMessagesBySessionId(id);
            if (messages == null || messages.Count == 0)
            {
                return NotFound();
            }
            return Ok(messages);
        }

        [HttpGet("{id}")]
        public IActionResult GetChatSessionMessageById(int id)
        {
            var message = _chatSessionMessageService.GetChatSessionMessageById(id);
            if (message == null)
            {
                return NotFound();
            }
            return Ok(message);
        }
    }
}