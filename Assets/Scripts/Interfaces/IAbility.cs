using Enums;

namespace Interfaces
{
    public interface IAbility
    {
        Stat Stat { get; }
        void AbilityAction();
    }
}