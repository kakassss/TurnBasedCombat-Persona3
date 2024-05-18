using Enums;

namespace Interfaces
{
    public interface IAbility
    {
        string AbilityName { get; }
        int ManaCost { get; }
        void AbilityAction(IMove activeEntity,IMove deactiveEntity);
        Stat Stat { get; }
        AbilityTypes AbilityTypes { get; }
    }
}