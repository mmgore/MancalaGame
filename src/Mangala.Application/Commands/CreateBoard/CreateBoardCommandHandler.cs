using Mancala.Domain.Entities;
using Mangala.Application.Extensions;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System.Threading;
using System.Threading.Tasks;

namespace Mangala.Application.Commands.CreateBoard
{
    public class CreateBoardCommandHandler : IRequestHandler<CreateBoardCommand, Unit>
    {
        private readonly IMemoryCache _memoryCache;
        public CreateBoardCommandHandler(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public async Task<Unit> Handle(CreateBoardCommand request, CancellationToken cancellationToken)
        {
            Board board = new Board();
            board.GameMessage = request.GameMessage;

            _memoryCache.SetCache(board);

            return Unit.Value;
        }
    }
}
