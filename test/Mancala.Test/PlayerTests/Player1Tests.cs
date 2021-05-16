using FluentAssertions;
using Mancala.Domain.Enum;
using System.Linq;
using Xunit;

namespace Mancala.Test.PlayerTests
{
    public class Player1Tests
    {
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 5)]
        [InlineData(5, 4)]
        [InlineData(6, 0)]
        public void Should_player1_move_success(int index, int expected)
        {
            //arrange
            var board = GenerateBoard.GenerateWithPlayer(PlayerType.Player1, playerInput: 2);
            var player = board.Players.FirstOrDefault(x => x.IsActive);
            //act
            var result = player.Move(board);
            //assert
            result.Houses[index].Count.Should().Be(expected);
        }

        [Theory]
        [InlineData(1, 0)]
        [InlineData(2, 5)]
        [InlineData(3, 4)]
        public void Should_player1_move_when_house_count_1_success(int index, int expected)
        {
            //arrange
            var board = GenerateBoard.GenerateWithPlayerAndHouse(PlayerType.Player1, playerInput: 2, houseCount: 1);
            var player = board.Players.FirstOrDefault(x => x.IsActive);
            //act
            var result = player.Move(board);
            //assert
            result.Houses[index].Count.Should().Be(expected);
        }

        [Theory]
        [InlineData(3, 9, 5, 1)]
        [InlineData(9, 9, 5, 0)]
        [InlineData(8, 9, 5, 5)]
        [InlineData(6, 9, 5, 7)]
        public void Should_player1_take_all_seed_to_his_safe_when_house_count_even(int index, int oppositeIndex, int oppositecount, int expected)
        {
            //arrange
            var board = GenerateBoard.GenerateWithPlayerAndHouse(PlayerType.Player1, playerInput: 4, houseCount: 7);
            board.Houses[oppositeIndex].Count = oppositecount;
            var player = board.Players.FirstOrDefault(x => x.IsActive);
            //act
            var result = player.Move(board);
            //assert
            result.Houses[index].Count.Should().Be(expected);
        }

        [Theory]
        [InlineData(0, 2, 1)]
        [InlineData(2, 2, 0)]
        [InlineData(10, 2, 0)]
        [InlineData(6, 2, 5)]
        public void Should_when_player1_play_and_last_seed_house_empty_take_all_opposite_house_seed_to_safe(int index, int targetIndex, int expected)
        {
            //arrange
            var board = GenerateBoard.GenerateWithPlayerAndHouse(PlayerType.Player1, playerInput: 1, houseCount: 3);
            board.Houses[targetIndex].Count = 0;
            var player = board.Players.FirstOrDefault(x => x.IsActive);
            // act
            var result = player.Move(board);
            //assert
            result.Houses[index].Count.Should().Be(expected);
        }

        [Fact]
        public void Should_player1_move_end_with_safe_and_play_again()
        {
            //arrange 
            var board = GenerateBoard.GenerateWithPlayer(PlayerType.Player1, playerInput: 4);
            var player = board.Players.FirstOrDefault(x => x.IsActive);
            //act
            var result = player.Move(board);
            //assert
            result.Players[0].IsActive.Should().BeTrue();
        }

        [Theory]
        [InlineData(5, 0)]
        [InlineData(6, 25)]
        public void Should_move_all_seed_to_safe_when_no_seed_remaining_on_player1_houses(int index, int expected)
        {
            //arrange
            var boardBefore = GenerateBoard.GenerateWithPlayer(PlayerType.Player1, playerInput: 6);
            var board = GenerateBoard.SetOneSideEmptyBoard(boardBefore, PlayerType.Player1);
            var player = board.Players.FirstOrDefault(x => x.IsActive);
            //act
            var result = player.Move(board);
            //assert
            result.Houses[index].Count.Should().Be(expected);
        }

    }
}
