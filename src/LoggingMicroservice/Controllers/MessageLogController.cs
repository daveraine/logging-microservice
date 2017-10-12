namespace LoggingMicroservice.Controllers
{
    using LoggingMicroservice.Core;
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("api/MessageLog")]
    public class MessageLogController : Controller
    {
        private readonly IMessageLog messageLog;

        public MessageLogController(IMessageLog messageLog)
        {
            this.messageLog = messageLog;
        }

        [HttpPost]
        public IActionResult Log(Message message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            messageLog.WriteEntry(message);

            return Ok();
        }
    }
}