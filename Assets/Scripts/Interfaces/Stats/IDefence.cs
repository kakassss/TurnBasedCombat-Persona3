using Enums;

namespace Interfaces.Stats
{
    public interface IDefence
    {
        void DefenceAction(IMove activeEntity,IMove deactiveEntity, Stat stat, int totalDamage);
        Stat Stat { get; }
        DefenceTypes DefenceTypes { get; }
    }
}