using Mancala.Domain.Entities;
using Mancala.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mancala.Domain.RuleContext.Rules
{
    public class Player2BoardEmptyRule : IRule
    {
        public Board Apply(Board board, PlayerType playerType)
        {
            if (P2TotalSeed(board).Equals(0))
                board.Houses[board.P2SafeIndex].Count += P1TotalSeed(board);

            return board;
        }

        public bool IsApplicable(PlayerType playerType) => (playerType == PlayerType.Player2);

        private int P1TotalSeed(Board board)
            => board.Houses.Take(6).Select(x => x.Count).Sum();

        private int P2TotalSeed(Board board)
            => board.Houses.Skip(7).Take(6).Select(x => x.Count).Sum();
    }
}
