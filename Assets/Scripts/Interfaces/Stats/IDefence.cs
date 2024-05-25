using Enums;

namespace Interfaces.Stats
{
    public interface IDefence
    {
        void DefenceAction(IMove activeEntity,IMove deactiveEntity, Stat stat, int totalDamage,int currentEntityIndex);
        Stat Stat { get; }
        DefenceTypes DefenceTypes { get; }
    }
}