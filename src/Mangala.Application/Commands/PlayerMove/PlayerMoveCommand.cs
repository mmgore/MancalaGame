using Mancala.Domain.Entities;
using Mancala.Domain.Enum;
using MediatR;

namespace Mangala.Application.Commands
{
    public class PlayerMoveCommand : IRequest<Board>
    {
        public int Input { get; set; }
        public PlayerType PlayerType { get; set; }
    }
}
