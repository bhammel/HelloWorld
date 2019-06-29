using System;
using HelloWorld.Api.Services;
using HelloWorld.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        /// <summary>
        /// Retrieves the details of an existing message.
        /// </summary>
        /// <param name="id">The unique message identifier.</param>
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] Guid id)
        {
            var response = _messageService.Get(id);
            if (!response.IsSuccessful)
            {
                return BadRequest(response.ProblemDetails);
            }

            if (response.Data == null)
            {
                return NotFound();
            }

            return Ok(MessageResponse.FromEntity(response.Data));
        }
    }
}
