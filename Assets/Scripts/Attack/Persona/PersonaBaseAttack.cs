using BaseEntity;
using Enums;
using Interfaces;

namespace Attack.Persona
{
    public abstract class PersonaBaseAttack : EntityBaseAttack, IPersonaAttack
    {
        public Stat Stat => _stat;
        public AttackTypes AttackTypes => _attackTypes;
        public virtual void AttackAction(IMove deactiveEntity, IMove activeEntity)
        {
            deactiveEntity.entity.TakeDamage(_entityBaseSo.BaseAttackValue + _attackDamageToEnemy);
            activeEntity.entity.TakeDamageUsingAttack(_attackDamageToItself);
        }
    }
}