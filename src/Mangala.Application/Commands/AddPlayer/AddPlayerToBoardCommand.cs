using Mancala.Domain.Enum;
using MediatR;

namespace Mangala.Application.Commands.AddPlayer
{
    public class AddPlayerToBoardCommand : IRequest
    {
        public string Username { get; set; }
        public PlayerType PlayerType { get; set; }
        public bool IsActive { get; set; }
    }
}
