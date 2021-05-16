using Mancala.Domain.Entities;
using Mancala.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mancala.Domain.RuleContext
{
    public class Player2MoveToPlayer1SideRule : IRule
    {
        public Board Apply(Board board, PlayerType playerType)
        {
            if (CheckIfPlayer2MovetoPlayer1Side(board.CurrentIndex, board.Houses.Count())) 
            {
                board.CurrentIndex = 0;
                board.MoveLastIndex -= board.Houses.Count();
            }
            return board;
        }

        public bool IsApplicable(PlayerType playerType) => (playerType == PlayerType.Player2);

        private bool CheckIfPlayer2MovetoPlayer1Side(int i, int index)
            => i == index;
    }
}
