using Enums;
using Interfaces;

namespace Attack.Persona
{
    public abstract class PersonaBaseAttack : EntityBaseAttack, IPersonaAttack
    {
        public Stat Stat => _stat;
        public AttackTypes AttackTypes => _attackTypes;
        public virtual void AttackAction(IMove activeEntity,IMove deactiveEntity)
        {
            activeEntity.entity.TakeDamageUsingAttack(_attackDamageToItself);
            deactiveEntity.entity.TakeDamage(deactiveEntity.entity.entityBaseSo.BaseAttackValue + _attackDamageToEnemy);
            
            EventBus<OnHealthChanged>.Fire(new OnHealthChanged
            {
                HealthPersona = deactiveEntity.entity.CurrentHealth,
                HealthShadow = activeEntity.entity.CurrentHealth
            });
        }
    }
}