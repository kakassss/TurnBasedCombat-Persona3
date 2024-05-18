using Enums;
using Interfaces;
using SignalBus;
using UnityEngine;

namespace Attack.Persona
{
    public abstract class PersonaBaseAttack : EntityBaseAttackData, IPersonaAttack
    {
        public Stat Stat => _stat;
        public AttackTypes AttackTypes => _attackTypes;
        public string AttackName => _attackName;
        public int AttackDamageToItself => _attackDamageToItself;
        public virtual void AttackAction(IMove activeEntity,IMove deactiveEntity) 
        {
            activeEntity.entity.TakeDamageUsingAttack(_attackDamageToItself);
            deactiveEntity.entity.TakeDamage((activeEntity.entity.entityBaseSo.BaseAttackValue + _attackDamageToEnemy) * (int)_attackTypes);
            
            Debug.Log("Persona " + Stat + " Attack! " + "Total Damage: " + (activeEntity.entity.entityBaseSo.BaseAttackValue + _attackDamageToEnemy) * (int)_attackTypes);
            
            activeEntity.MoveAction();
            EventBus<OnHealthChanged>.Fire(new OnHealthChanged());
        }
    }
}