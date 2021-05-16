using FluentValidation;

namespace Mangala.Application.Commands.PlayerMove
{
    public class PlayerMoveCommandValidator : AbstractValidator<PlayerMoveCommand>
    {
        public PlayerMoveCommandValidator()
        {
            RuleFor(r => r.Input)
                .Must(IsInputValid)
                .WithMessage("Your input must be between 1 and 6");
        }

        private bool IsInputValid(int input) =>
            input <= 6 && input > 0;
    }
}
