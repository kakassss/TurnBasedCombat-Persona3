using BaseEntity;
using Enums;

namespace Interfaces
{
    public interface IAttack
    {
        void AttackAction(IMove activeEntity,IMove deactiveEntity);
        Stat Stat { get; }
        AttackTypes AttackTypes { get; }
    }
}
