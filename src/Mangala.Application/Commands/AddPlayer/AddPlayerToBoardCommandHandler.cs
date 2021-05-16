using Mancala.Domain.Entities;
using Mangala.Application.Extensions;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System.Threading;
using System.Threading.Tasks;

namespace Mangala.Application.Commands.AddPlayer
{
    public class AddPlayerToBoardCommandHandler : IRequestHandler<AddPlayerToBoardCommand, Unit>
    {
        private readonly IMemoryCache _memoryCache;
        public AddPlayerToBoardCommandHandler(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public async Task<Unit> Handle(AddPlayerToBoardCommand request, CancellationToken cancellationToken)
        {
            Board board = _memoryCache.Get("board") as Board;

            var player = new Player(request.Username, request.IsActive, request.PlayerType, 0);
            board.AddPlayer(player);

            _memoryCache.RemoveCache();
            _memoryCache.SetCache(board);

            return Unit.Value;
        }
    }
}
