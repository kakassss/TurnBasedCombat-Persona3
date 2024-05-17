using Enums;
using Interfaces;
using UnityEngine;

namespace Attack.Persona
{
    public abstract class PersonaBaseAttack : EntityBaseAttackData, IPersonaAttack
    {
        public string AttackName => _attackName;
        public Stat Stat => _stat;
        public AttackTypes AttackTypes => _attackTypes;
        public virtual void AttackAction(IMove activeEntity,IMove deactiveEntity) 
        {
            activeEntity.entity.TakeDamageUsingAttack(_attackDamageToItself);
            deactiveEntity.entity.TakeDamage((activeEntity.entity.entityBaseSo.BaseAttackValue + _attackDamageToEnemy) * (int)_attackTypes);
            
            Debug.Log(deactiveEntity.GetType().Name + " " + deactiveEntity.entity.CurrentHealth + activeEntity.GetType().Name + " " +  activeEntity.entity.CurrentHealth);
            Debug.Log("Persona " + Stat + " Attack! " + "Total Damage: " + (activeEntity.entity.entityBaseSo.BaseAttackValue + _attackDamageToEnemy) * (int)_attackTypes);
            
            EventBus<OnHealthChanged>.Fire(new OnHealthChanged());
        }
    }
}