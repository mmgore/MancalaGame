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
        public string Username { get; private set; }
        public bool IsActive { get; private set; }
        public PlayerType PlayerType { get; private set; }
        public int PlayerInput { get; private set; }

        public Player(string username, bool isActice, PlayerType playerType)
        {
            Username = username;
            IsActive = isActice;
            PlayerType = playerType;
        }

        public static Player Create(string username, bool isActive, PlayerType playerType)
        {
            return new Player(username, isActive, playerType);
        }

        public Player SetPlayerInput(int playerInput)
        {
            this.PlayerInput = playerInput;
            return this;
        }

        public Player SetIsActive(bool isActive)
        {
            this.IsActive = isActive;
            return this;
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
