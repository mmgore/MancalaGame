using Mancala.Domain.Entities;
using Mancala.Domain.Enum;
using System;

namespace Mancala.Domain.RuleContext
{
    public class HouseEvenAfterPlayer1MoveRule : IRule
    {
        public Board Apply(Board board, PlayerType playerType)
        {
            if (CheckIfHouseEvenAfterPlayerLastSeedMove(board, P1Check))
            {
                board.Houses[board.P1SafeIndex].Count += board.Houses[board.MoveLastIndex].Count;
                board.Houses[board.MoveLastIndex].Count = 0;
            }
            return board;
        }

        public bool IsApplicable(PlayerType playerType) => (playerType == PlayerType.Player1);

        private bool CheckIfHouseEvenAfterPlayerLastSeedMove(Board board, Func<int, bool> checkPlayer)
            => board.CurrentIndex == board.MoveLastIndex && board.Houses[board.MoveLastIndex].Count % 2 == 0 && checkPlayer(board.CurrentIndex);

        private bool P1Check(int i)
            => i > 6;
    }
}
