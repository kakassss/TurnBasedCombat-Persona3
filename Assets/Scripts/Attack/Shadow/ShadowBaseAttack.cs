using Enums;
using Interfaces;
using UnityEngine;

namespace Attack.Shadow
{
    public abstract class ShadowBaseAttack : EntityBaseAttackData, IShadowAttack
    {
        public Stat Stat => _stat;
        public AttackTypes AttackTypes => _attackTypes;

        public virtual void AttackAction(IMove activeEntity,IMove deactiveEntity)
        {
            activeEntity.entity.TakeDamageUsingAttack(_attackDamageToItself);
            deactiveEntity.entity.TakeDamage(activeEntity.entity.entityBaseSo.BaseAttackValue + _attackDamageToEnemy);
            
            
            Debug.Log(deactiveEntity.GetType().Name + " " + deactiveEntity.entity.CurrentHealth + activeEntity.GetType().Name + " " +  activeEntity.entity.CurrentHealth);

            EventBus<OnHealthChanged>.Fire(new OnHealthChanged());
        }
    }
}