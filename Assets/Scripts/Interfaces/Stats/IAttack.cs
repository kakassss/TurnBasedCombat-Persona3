using System.Collections.Generic;
using Enums;

namespace Interfaces.Stats
{
    public interface IAttack
    {
        string AttackName { get; }
        int AttackDamageToItself { get; }
        void AttackAction(IMove activeEntity,List<IMove> allDeactiveEntities);
        Stat Stat { get; }
        AttackTypes AttackTypes { get; }
    }
}
