using FluentAssertions;
using FluentValidation.TestHelper;
using Mangala.Application.Commands;
using Mangala.Application.Commands.PlayerMove;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Mancala.Test.ApplicationTests.PlayerMove
{
    public class PlayerMoveTests
    {
        [Fact]
        public void Should_player_input_not_valid()
        {
            var memoryCache = Mock.Of<IMemoryCache>();
            var command = new PlayerMoveCommand { Input = 7, PlayerType = Domain.Enum.PlayerType.Player1};
            //var handler = new PlayerMoveCommandHandler(memoryCache);

            var validator = new PlayerMoveCommandValidator();

            //var result =  handler.Handle(command, CancellationToken.None);
           
            validator.ShouldHaveValidationErrorFor(command => command.Input, command.Input)
                .WithErrorMessage("Your input must be between 1 and 6");

        }
    }
}
