using Mancala.Domain.Entities;
using Mancala.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mancala.Domain.RuleContext
{
    public class HouseEvenAfterPlayer2MoveRule : IRule
    {
        public Board Apply(Board board, PlayerType playerType)
        {
            if (CheckIfHouseEvenAfterPlayerLastSeedMove(board, P2Check))
            {
                board.Houses[board.P2SafeIndex].Count += board.Houses[board.MoveLastIndex].Count;
                board.Houses[board.MoveLastIndex].Count = 0;
            }
            return board;
        }

        public bool IsApplicable(PlayerType playerType) => (playerType == PlayerType.Player2);

        private bool CheckIfHouseEvenAfterPlayerLastSeedMove(Board board, Func<int, bool> checkPlayer)
            => board.CurrentIndex == board.MoveLastIndex && board.Houses[board.MoveLastIndex].Count % 2 == 0 && checkPlayer(board.CurrentIndex);

        private bool P2Check(int i)
            => i < 6;
    }
}
