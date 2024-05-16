using BaseEntity;
using Enums;

namespace Interfaces
{
    public interface IAttack
    {
        void AttackAction(IMove deactiveEntity,IMove activeEntity);
        Stat Stat { get; }
        AttackTypes AttackTypes { get; }
    }
}
