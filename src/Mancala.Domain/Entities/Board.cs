using Mancala.Domain.Common;
using Mancala.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mancala.Domain.Entities
{
    public class Board
    {
        public Board()
        {
            Houses = new List<Seed>();
            Players = new List<Player>();
            SetHouses(Houses);
        }
        public List<Seed> Houses { get; set; }
        public List<Player> Players { get; set; }
        public int CurrentIndex { get; set; }
        public int MoveLastIndex { get; set; }
        public string GameMessage { get; set; }
        public int P1SafeIndex { get; set; } = 6;
        public int P2SafeIndex { get; set; } = 13;
        public bool IsGameFinished { get; set; } = false;

        public void SetHouses(List<Seed> houses)
        {
            for (int i = 0; i < 14; i++)
            {
                Seed seed = new Seed
                {
                    Count = 4
                };
                if (i == 6 || i == 13)
                {
                    seed.Count = 0;
                }
                houses.Add(seed);
            }
        }

        public int SetMoveCount(Board board)
        {
            int seedCount = board.Houses[this.CurrentIndex].Count;
            if (seedCount == 1)
            {
                board.MoveLastIndex = this.CurrentIndex + 1;
                board.Houses[this.CurrentIndex].Count = 0;
            }
            else
            {
                board.MoveLastIndex = this.CurrentIndex + seedCount - 1;
                board.Houses[this.CurrentIndex].Count = 1;
            }
            return board.MoveLastIndex;
        }

        public int SetCurrentIndex(Player player) =>
            (player.PlayerType == PlayerType.Player2) ? player.PlayerInput + 6 : player.PlayerInput - 1;

        public Board AddPlayer(Player player)
        {
            this.ThrowIf(board => board.Players.Count >= 2, new InvalidOperationException());

            Players.Add(player);
            return this;
        }
    }
}
