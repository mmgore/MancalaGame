using FluentAssertions;
using Mancala.Domain.Enum;
using System.Linq;
using Xunit;

namespace Mancala.Test.PlayerTests
{
    public class Player2Tests
    {
        [Theory]
        [InlineData(7, 1)]
        [InlineData(8, 5)]
        [InlineData(11, 4)]
        [InlineData(13, 0)]
        public void Should_player2_move_sucecess(int index, int expected)
        {
            //arrange
            var board = GenerateBoard.GenerateWithPlayer(PlayerType.Player2, playerInput: 1);
            var player = board.Players.FirstOrDefault(x => x.IsActive);
            //act 
            var result = player.Move(board);
            //assert
            result.Houses[index].Count.Should().Be(expected);
        }
        [Theory]
        [InlineData(11, 1)]
        [InlineData(13, 1)]
        [InlineData(0, 5)]
        [InlineData(1, 4)]
        public void Should_player2_move_to_player1_side_success(int index, int expected)
        {
            //arrange
            var board = GenerateBoard.GenerateWithPlayer(PlayerType.Player2, playerInput: 5);
            var player = board.Players.FirstOrDefault(x => x.IsActive);
            //act
            var result = player.Move(board);
            //assert
            result.Houses[index].Count.Should().Be(expected);
        }

        [Fact]
        public void Should_player2_move_end_with_safe_and_play_again()
        {
            //arrange 
            var board = GenerateBoard.GenerateWithPlayer(PlayerType.Player2, playerInput: 4);
            var player = board.Players.FirstOrDefault(x => x.IsActive);
            //act
            var result = player.Move(board);
            //assert
            result.Players[0].IsActive.Should().BeTrue();
        }
        [Theory]
        [InlineData(7, 9, 1)]
        [InlineData(9, 9, 0)]
        [InlineData(3, 9, 0)]
        [InlineData(13, 9, 5)]
        public void Should_when_player2_play_and_last_seed_house_empty_take_all_opposite_house_seed_to_safe(int index, int targetIndex, int expected)
        {
            //arrange
            var board = GenerateBoard.GenerateWithPlayerAndHouse(PlayerType.Player2, playerInput: 1, houseCount: 3);
            board.Houses[targetIndex].Count = 0;
            var player = board.Players.FirstOrDefault(x => x.IsActive);
            //act
            var result = player.Move(board);
            //assert
            result.Houses[index].Count.Should().Be(expected);
        }
        [Theory]
        [InlineData(10, 1, 5, 1)]
        [InlineData(1, 1, 5, 0)]
        [InlineData(13, 1, 5, 7)]
        public void Should_player2_take_all_seed_to_his_safe_when_house_count_even(int index, int oppositeIndex, int oppositecount, int expected)
        {
            //arrange
            var board = GenerateBoard.GenerateWithPlayerAndHouse(PlayerType.Player2, playerInput: 4, houseCount: 6);
            board.Houses[oppositeIndex].Count = oppositecount;
            var player = board.Players.FirstOrDefault(x => x.IsActive);
            //act
            var result = player.Move(board);
            //assert
            result.Houses[index].Count.Should().Be(expected);
        }

        [Theory]
        [InlineData(12, 0)]
        [InlineData(13, 25)]
        public void Should_move_all_seed_to_safe_when_no_seed_remaining_on_player2_houses(int index, int expected)
        {
            //arrange
            var boardBefore = GenerateBoard.GenerateWithPlayer(PlayerType.Player2, playerInput: 6);
            var board = GenerateBoard.SetOneSideEmptyBoard(boardBefore, PlayerType.Player2);
            var player = board.Players.FirstOrDefault(x => x.IsActive);
            //act
            var result = player.Move(board);
            //assert
            result.Houses[index].Count.Should().Be(expected);
        }
    }
}
