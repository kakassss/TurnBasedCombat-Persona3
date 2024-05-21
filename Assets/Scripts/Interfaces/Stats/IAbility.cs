using System.Collections.Generic;
using Enums;

namespace Interfaces.Stats
{
    public interface IAbility
    {
        string AbilityName { get; }
        int ManaCost { get; }
        void AbilityAction(IMove activeEntity,List<IMove> allDeactiveEntities);
        Stat Stat { get; }
        AbilityTypes AbilityTypes { get; }
    }
}