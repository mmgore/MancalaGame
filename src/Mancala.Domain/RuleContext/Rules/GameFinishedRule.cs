using Mancala.Domain.Entities;
using Mancala.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mancala.Domain.RuleContext.Rules
{
    public class GameFinishedRule : IRule
    {
        public Board Apply(Board board, PlayerType playerType)
        {
            int totalSum = P1TotalSeed(board) + P2TotalSeed(board);
            if (totalSum.Equals(0))
            {
                board.IsGameFinished = true;
                //board.GameMessage = (board.Houses[board.P1SafeIndex].Count > board.Houses[board.P2SafeIndex].Count) ?
                //                        "Game finished. Player1 won" :
                //                    (board.Houses[board.P1SafeIndex].Count < board.Houses[board.P2SafeIndex].Count) ?
                //                        "Game finished. Player2 won" :
                //                        "Game finished. Draw";
                board.GameMessage = GameResult().First(r => r.eval(board)).message;
            }

            return board;
        }

        public bool IsApplicable(PlayerType playerType) => true;

        private int P1TotalSeed(Board board)
            => board.Houses.Take(6).Select(x => x.Count).Sum();

        private int P2TotalSeed(Board board)
            => board.Houses.Skip(7).Take(6).Select(x => x.Count).Sum();

        private bool CheckResult(int c1, int c2)
            => c1 > c2;

        private List<(Func<Board, bool> eval, string message)> GameResult() =>
            new List<(Func<Board, bool> eval, string message)>
            {
                (board => CheckResult(board.Houses[board.P1SafeIndex].Count, board.Houses[board.P2SafeIndex].Count), "Game finished. Player1 won"),
                (board => CheckResult(board.Houses[board.P2SafeIndex].Count, board.Houses[board.P1SafeIndex].Count), "Game finished. Player2 won"),
                (board => true, "Game finished. Draw")
            };
    }
}
