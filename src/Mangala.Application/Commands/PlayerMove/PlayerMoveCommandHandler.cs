using Mancala.Domain.Entities;
using Mangala.Application.Extensions;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mangala.Application.Commands
{
    public class PlayerMoveCommandHandler : IRequestHandler<PlayerMoveCommand, Board>
    {
        private readonly IMemoryCache _memoryCache;
        public PlayerMoveCommandHandler(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public async Task<Board> Handle(PlayerMoveCommand request, CancellationToken cancellationToken)
        {
            Board board = _memoryCache.Get("board") as Board;
            var player = board.Players.FirstOrDefault(x => x.PlayerType == request.PlayerType);
            player.PlayerInput = request.Input;
            player.Move(board);
            _memoryCache.RemoveCache();
            _memoryCache.SetCache(board);
            return board;
        }
    }
}
