using BaseEntity;
using Enums;
using Interfaces;

namespace Attack.Shadow
{
    public abstract class ShadowBaseAttack : EntityBaseAttack, IShadowAttack
    {
        public Stat Stat => _stat;
        public AttackTypes AttackTypes => _attackTypes;

        public abstract void AttackAction(IMove deactiveEntity,IMove activeEntity);
    }
}