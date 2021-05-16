using Mancala.Domain.Entities;
using Mancala.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mancala.Domain.RuleContext
{
    public class Player1LastSeedWentToEmptyHouseRule : IRule
    {
        public Board Apply(Board board, PlayerType playerType)
        {
            if (CheckIfPlayerLastSeedWenttoEmptyHouse(board))
                SetSafeCountAccordingtoPlayertype(board);
            else
                board.Houses[board.CurrentIndex].Count += 1;

            return board;
        }

        public bool IsApplicable(PlayerType playerType) => (playerType == PlayerType.Player1);
        private bool CheckIfPlayerLastSeedWenttoEmptyHouse(Board board)
            => board.CurrentIndex == board.MoveLastIndex && board.Houses[board.MoveLastIndex].Count == 0 && board.CurrentIndex != board.P1SafeIndex;

        private void SetSafeCountAccordingtoPlayertype(Board board)
        {
            int targetIndex = 12 - board.CurrentIndex;
            board.Houses[board.P1SafeIndex].Count = board.Houses[targetIndex].Count + 1;
            board.Houses[board.CurrentIndex].Count = 0;
            board.Houses[targetIndex].Count = 0;
        }
    }
}
