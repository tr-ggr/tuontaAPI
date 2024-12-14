using Microsoft.AspNetCore.Mvc;
using tuontaAPI.DTO;
using tuontaAPI.Interfaces;

namespace tuontaAPI.Controllers
{
    [Route("api/chats/items")]
    [ApiController]
    public class ChatItemController : ControllerBase
    {
        private readonly IChatItemService _chatItemService;

        public ChatItemController(IChatItemService chatItemService)
        {
            _chatItemService = chatItemService;
        }

        [HttpGet]
        public ActionResult<List<ChatItemDto>> GetChatItems()
        {
            return Ok(_chatItemService.GetChatItems());
        }

        [HttpGet("{id}")]
        public ActionResult<ChatItemDto> GetChatItemById(int id)
        {
            // id : Current User

            var chatItem = _chatItemService.GetChatItem(id);
            if (chatItem == null)
            {
                return NotFound();
            }
            return Ok(chatItem);
        }

        [HttpPost]
        public ActionResult AddChatItem([FromBody] ChatItemDto chatItemDto)
        {
            if (_chatItemService.AddChatItem(chatItemDto))
            {
                return Ok();
            }
            return BadRequest();
        }


    }
}


