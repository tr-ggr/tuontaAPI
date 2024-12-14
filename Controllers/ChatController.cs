using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using tuontaAPI.DTO;
using tuontaAPI.Interfaces;

namespace tuontaAPI.Controllers
{

    [Route("api/chats")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpGet]
        public ActionResult<List<ChatDto>> GetChats()
        {
            return Ok(_chatService.GetChats());
        }

        [HttpGet("user_id/{id}")]
        public ActionResult<ChatDto> GetChatByUserId(int id)
        {
            var chat = _chatService.GetChatsByUser1Id(id);
            if (chat == null)
            {
                return NotFound();
            }
            return Ok(chat);
        }

        [HttpGet("{id}")]
        public ActionResult<ChatDto> GetChatById(int id)
        {
            var chat = _chatService.GetChatById(id);
            if (chat == null)
            {
                return NotFound();
            }
            return Ok(chat);
        }
    }
}


