using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineChat.Api.Core.Commands.Auth.Login;

namespace OnlineChat.Api.Controllers
{
    public class AccessController : Controller
    {
        private readonly IMediator _mediator;
        public AccessController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginCommand request)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            return Ok(await _mediator.Send(request));
        }
    }
}
