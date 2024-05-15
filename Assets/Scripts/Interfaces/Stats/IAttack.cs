using Enums;

namespace Interfaces
{
    public interface IAttack
    {
        void AttackAction();
        Stat Stat { get; }
        AttackTypes AttackTypes { get; }
    }
}
