using Enums;

namespace Interfaces
{
    public interface IAbility
    {
        void AbilityAction(IMove activeEntity,IMove deactiveEntity);
        Stat Stat { get; }
        AttackTypes AttackTypes { get; }
    }
}