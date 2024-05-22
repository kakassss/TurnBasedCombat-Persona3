using System.Collections.Generic;
using Enums;
using Interfaces;
using Interfaces.Stats;
using SelectShadow;
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
        
        public virtual void AttackAction(IMove activeEntity,List<IMove> allDeactiveEntities)
        {
            var targetShadow = allDeactiveEntities[SelectTargetShadow.CurrentShadowIndex];
            var totalDamage = activeEntity.entity.entityBaseSo.BaseAttackValue + _attackDamageToEnemy * (int)_attackTypes;
            
            activeEntity.entity.TakeDamageUsingAttack(_attackDamageToItself);
            targetShadow.entity.TakeDamage(totalDamage);
            
            Debug.Log("Persona " + Stat + " Attack! " + "Total Damage: " + totalDamage);
            
            activeEntity.MoveAction();
            EventBus<OnHealthChanged>.Fire(new OnHealthChanged());
            EventBus<OnTakeDamage>.Fire(new OnTakeDamage
            {
                Stat =  _stat,
            });
        }
    }
}