using Mancala.Domain.Common;
using Mancala.Domain.Enum;
using Mancala.Domain.Exceptions;
using Mancala.Domain.RuleContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mancala.Domain.Entities
{
    public class Player
    {
        public string Username { get; set; }
        public bool IsActive { get; set; }
        public PlayerType PlayerType { get; set; }
        public int PlayerInput { get; set; }

        public Player(string username, bool isActice, PlayerType playerType, int playerInput)
        {
            Username = username;
            IsActive = isActice;
            PlayerType = playerType;
            PlayerInput = playerInput;
        }

        public Board Move(Board board)
        {   
            this.ThrowIf(player => !player.IsActive, new InvalidPlayerException());
            
            board.CurrentIndex = board.SetCurrentIndex(this);
            
            board.ThrowIf(board => board.Houses[board.CurrentIndex].Count == 0, new InvalidHouseSelectedException());

            board.MoveLastIndex =  board.SetMoveCount(board);

            for (board.CurrentIndex += 1; board.CurrentIndex <= board.MoveLastIndex; board.CurrentIndex++)
            {
                board = RuleContextProvider.Apply(board, this.PlayerType);
            }
            return board;
        }
    }
}
