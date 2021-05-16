using MediatR;

namespace Mangala.Application.Commands.CreateBoard
{
    public class CreateBoardCommand : IRequest
    {
        public string GameMessage { get; set; }
    }
}
