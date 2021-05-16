using Mancala.Domain.Entities;
using Mancala.Domain.Enum;
using Mancala.Domain.RuleContext.Rules;
using System.Collections.Generic;

namespace Mancala.Domain.RuleContext
{
    public static class RuleContextProvider
    {
        private readonly static IList<IRule> _playerRules = new List<IRule>();
        static RuleContextProvider()
        {
            _playerRules.Add(new Player2MoveToPlayer1SideRule());
            _playerRules.Add(new Player1LastSeedWentToEmptyHouseRule());
            _playerRules.Add(new Player2LastSeedWentToEmptyHouseRule());
            _playerRules.Add(new HouseEvenAfterPlayer1MoveRule());
            _playerRules.Add(new HouseEvenAfterPlayer2MoveRule());
            _playerRules.Add(new ChangeActivePlayerRule());
            _playerRules.Add(new Player1LastSeedGoesToSafeRule());
            _playerRules.Add(new Player2LastSeedGoesToSafeRule());
            _playerRules.Add(new Player1BoardEmptyRule());
            _playerRules.Add(new Player2BoardEmptyRule());
            _playerRules.Add(new GameFinishedRule());
        }
        public static Board Apply(Board board, PlayerType playerType)
        {
            foreach (var rule in _playerRules)
            {
                if (rule.IsApplicable(playerType))
                    rule.Apply(board, playerType);
            }
            return board;
        }
    }
}
