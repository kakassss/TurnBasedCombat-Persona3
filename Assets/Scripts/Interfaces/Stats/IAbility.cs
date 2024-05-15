using Enums;

namespace Interfaces
{
    public interface IAbility
    {
        void AbilityAction();
        Stat Stat { get; }
        AttackTypes AttackTypes { get; }
    }
}