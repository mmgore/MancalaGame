using Mancala.Domain.Entities;
using Mancala.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;

namespace Mancala.Test
{
    public class GenerateBoard
    {
        public static Board GenerateWithPlayer(PlayerType playerType, int playerInput, bool isActive=true)
        {
            var board = new Board();
            var player = BuildPlayer.With().Defaults().PlayerType(playerType).PlayerInput(playerInput).IsActive(isActive).Build();
            board.AddPlayer(player);
            return board;
        }

        public static Board GenerateWithPlayerAndHouse(PlayerType playerType, int playerInput, int houseCount)
        {
            var board = new Board();
            int houseIndex = (playerType == PlayerType.Player1) ? playerInput - 1 : playerInput + 6;
            board.Houses[houseIndex].Count = houseCount;
            var player = BuildPlayer.With().Defaults().PlayerType(playerType).PlayerInput(playerInput).Build();
            board.AddPlayer(player);
            return board;
        }
        public static Board SetOneSideEmptyBoard(Board board, PlayerType playerType)
        {
            int index = (playerType == PlayerType.Player1) ? 0 : 7;
            
            for (int i = index; i < index+5; i++)
            {
                board.Houses[i].Count = 0;
            }
            board.Houses[index + 5].Count = 1;
            return board;
        }
        public static Board GenerateEmptyBoard(PlayerType playerType, int playerInput, int p1SafeIndex, int p2SafeIndex)
        {
            var board = new Board();
            var player = BuildPlayer.With().Defaults().PlayerType(playerType).PlayerInput(playerInput).Build();
            board.AddPlayer(player);
            for (int i = 0; i < 14; i++)
            {
                board.Houses[i].Count = 0;
            }
            board.Houses[6].Count = p1SafeIndex;
            board.Houses[13].Count = p2SafeIndex;

            return board;
        }

    }
}
