using Mancala.Domain.Entities;
using Mancala.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mancala.Domain.RuleContext.Rules
{
    public class ChangeActivePlayerRule : IRule
    {
        public Board Apply(Board board, PlayerType playerType)
        {
            var activePlayer = board.Players.FirstOrDefault(x => x.PlayerType == playerType);

            var otherPlayer = (activePlayer.PlayerType == PlayerType.Player1) ? board.Players.FirstOrDefault(x => x.PlayerType == PlayerType.Player2) : board.Players.FirstOrDefault(x => x.PlayerType == PlayerType.Player1);

            activePlayer.IsActive = false;
            if (otherPlayer != null)
            {
                otherPlayer.IsActive = true;
            }

            return board;
        }

        public bool IsApplicable(PlayerType playerType) => true;
    }
}
