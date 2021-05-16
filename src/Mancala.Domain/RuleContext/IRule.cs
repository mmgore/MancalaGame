using Mancala.Domain.Entities;
using Mancala.Domain.Enum;

namespace Mancala.Domain.RuleContext
{
    public interface IRule
    {
        bool IsApplicable(PlayerType playerType);
        Board Apply(Board board, PlayerType playerType);
    }
}
