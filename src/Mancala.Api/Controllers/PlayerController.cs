using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mangala.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mancala.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PlayerController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        [HttpPost]
        public async Task<IActionResult> Move([FromBody] PlayerMoveCommand command)
            => Ok(await _mediator.Send(command));
    }
}
