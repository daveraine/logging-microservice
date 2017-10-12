namespace LoggingMicroservice.Controllers
{
    using LoggingMicroservice.Core;
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("api/MessageLog")]
    public class MessageLogController : Controller
    {
        [HttpPost]
        public IActionResult Log(Message message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok();
        }
    }
}