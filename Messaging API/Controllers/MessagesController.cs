using Microsoft.AspNetCore.Mvc;
using MessagingApi.Services;
using MessagingApi.Models;

namespace MessagingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _service;
        public MessagesController(IMessageService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Message>> GetAll() => Ok(_service.GetAll());

        [HttpGet("{id}")]
        public ActionResult<Message> GetById(Guid id)
        {
            var message = _service.GetById(id);
            return message is null ? NotFound() : Ok(message);
        }

        [HttpPost]
        public ActionResult<Message> Create([FromBody] MessageInput input)
        {
            if(string.IsNullOrWhiteSpace(input.Content))
            {
                return BadRequest("Message content is required.");
            }

            var message = _service.Create(input.Content);
            return CreatedAtAction(nameof(GetById), new { id = message.Id}, message);
        }

        public class MessageInput
        {
            public string Content { get; set; } = string.Empty;
        }
    }
}
