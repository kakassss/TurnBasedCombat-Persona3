using Enums;

namespace Interfaces
{
    public interface IAttack
    {
        string AttackName { get; }
        int AttackDamageToItself { get; }
        void AttackAction(IMove activeEntity,IMove deactiveEntity);
        Stat Stat { get; }
        AttackTypes AttackTypes { get; }
    }
}
