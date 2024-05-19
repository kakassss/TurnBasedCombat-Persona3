using Enums;

namespace Interfaces
{
    public interface IDefence
    {
        void DefenceAction(IMove deactiveEntity, Stat stat);
        Stat Stat { get; }
        DefenceTypes DefenceTypes { get; }
    }
}