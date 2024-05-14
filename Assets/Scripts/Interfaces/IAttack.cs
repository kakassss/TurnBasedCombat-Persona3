using Enums;

namespace Interfaces
{
    public interface IAttack
    {
        void Attack();
        Stat Stat { get; }
        AttackTypes AttackTypes { get; }
    }
}
