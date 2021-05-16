using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mangala.Application.Commands.AddPlayer;
using Mangala.Application.Commands.CreateBoard;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mancala.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BoardController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        [HttpPost("add-player")]
        public async Task<IActionResult> AddPlayer([FromBody] AddPlayerToBoardCommand command)
            => Ok(await _mediator.Send(command));
        [HttpPost("create-board")]
        public async Task<IActionResult> Create([FromBody] CreateBoardCommand command)
            => Ok(await _mediator.Send(command));
    }
}
