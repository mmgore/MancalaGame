using Mancala.Domain.Entities;
using Mancala.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mancala.Domain.RuleContext.Rules
{
    public class Player2LastSeedGoesToSafeRule : IRule
    {
        public Board Apply(Board board, PlayerType playerType)
        {
            var currentPlayer = board.Players.FirstOrDefault(x => x.PlayerType == playerType);

            if (CheckIfPlayerLastSeedGoestoSafe(board, currentPlayer))
            {
                currentPlayer.SetIsActive(true);
                board.GameMessage = $"{currentPlayer.PlayerType} turn";
            }
            return board;
        }

        public bool IsApplicable(PlayerType playerType) => (playerType == PlayerType.Player2);

        private bool CheckIfPlayerLastSeedGoestoSafe(Board board, Player player)
            => board.CurrentIndex == board.MoveLastIndex && player.PlayerType == PlayerType.Player2 && board.CurrentIndex == board.P2SafeIndex;
    }
}
