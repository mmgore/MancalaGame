using FluentValidation;

namespace Mangala.Application.Commands.AddPlayer
{
    public class AddPlayerToBoardCommandValidator : AbstractValidator<AddPlayerToBoardCommand>
    {
        public AddPlayerToBoardCommandValidator()
        {
            RuleFor(r => r.Username).NotEmpty();
        }
    }
}
