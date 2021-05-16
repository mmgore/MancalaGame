using FluentAssertions;
using Mancala.Domain.Entities;
using Mancala.Domain.Enum;
using Mancala.Domain.Exceptions;
using Mancala.Domain.RuleContext.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Mancala.Test
{
    public class PlayerCommonTests
    {
        [Theory]
        [InlineData(3, 0)]
        [InlineData(4, 0)]
        [InlineData(5, 0)]
        public void Should_selected_house_not_be_empty(int playerInput, int houseCount)
        {
            //arrange
            var board = GenerateBoard.GenerateWithPlayerAndHouse(PlayerType.Player1, playerInput, houseCount);
            var player = board.Players.FirstOrDefault(x => x.IsActive);
            //act
            Action act = () => player.Move(board);
            //assert
            act.Should().Throw<InvalidHouseSelectedException>();
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void Should_when_player_is_not_active_throw_execption(int playerInput)
        {
            //arrange            
            var board = GenerateBoard.GenerateWithPlayer(PlayerType.Player1, playerInput, isActive: false);
            var player = board.Players.FirstOrDefault(x => !x.IsActive);
            //act
            Action act = () => player.Move(board);
            //assert
            act.Should().Throw<InvalidPlayerException>();
        }
        
        [Theory]
        [InlineData(5, 5, 0)]
        [InlineData(6, 5, 31)]
        public void Should_player1_won_the_game(int index, int selectedCount, int expected)
        {
            //arrange
            var board = GenerateBoard.GenerateEmptyBoard(PlayerType.Player1, playerInput:6, p1SafeIndex: 30, p2SafeIndex: 17);
            board.Houses[selectedCount].Count = 1;
            var player = board.Players.FirstOrDefault(x => x.IsActive);
            //act
            var result = player.Move(board);
            //assert
            result.Houses[index].Count.Should().Be(expected);
            result.IsGameFinished.Should().BeTrue();
            result.GameMessage.Should().Be("Game finished. Player1 won");
        }
        [Theory]
        [InlineData(12, 12, 0)]
        [InlineData(13, 12, 31)]
        public void Should_player2_won_the_game(int index, int selectedCount, int expected)
        {
            //arrange
            var board = GenerateBoard.GenerateEmptyBoard(PlayerType.Player2, playerInput: 6, p1SafeIndex: 17, p2SafeIndex: 30);
            board.Houses[selectedCount].Count = 1;
            var player = board.Players.FirstOrDefault(x => x.IsActive);
            //act
            var result = player.Move(board);
            //assert
            result.Houses[index].Count.Should().Be(expected);
            result.IsGameFinished.Should().BeTrue();
            result.GameMessage.Should().Be("Game finished. Player2 won");
        }
        [Theory]
        [InlineData(5, 5, 0)]
        [InlineData(6, 5, 24)]
        public void Should_game_end_with_draw(int index, int selectedCount, int expected)
        {
            //arrange
            var board = GenerateBoard.GenerateEmptyBoard(PlayerType.Player1, playerInput: 6, p1SafeIndex: 23, p2SafeIndex: 24);
            board.Houses[selectedCount].Count = 1;
            var player = board.Players.FirstOrDefault(x => x.IsActive);
            //act
            var result = player.Move(board);
            //assert
            result.Houses[index].Count.Should().Be(expected);
            result.IsGameFinished.Should().BeTrue();
            result.GameMessage.Should().Be("Game finished. Draw");
        }
    }
}
