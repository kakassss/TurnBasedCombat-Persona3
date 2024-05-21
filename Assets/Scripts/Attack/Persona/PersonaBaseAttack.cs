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
        
        private int _randomShadow;
        public virtual void AttackAction(IMove activeEntity,List<IMove> allDeactiveEntities)
        {
            _randomShadow = Helper.GetRandomNumber(0, allDeactiveEntities.Count);
            
            Debug.Log("onur burda " + SelectTargetShadow.CurrentShadowIndex);
            var targetShadow = allDeactiveEntities[SelectTargetShadow.CurrentShadowIndex];
            
            activeEntity.entity.TakeDamageUsingAttack(_attackDamageToItself);
            targetShadow.entity.TakeDamage((activeEntity.entity.entityBaseSo.BaseAttackValue + _attackDamageToEnemy) * (int)_attackTypes);
            
            Debug.Log("Persona " + Stat + " Attack! " + "Total Damage: " + (activeEntity.entity.entityBaseSo.BaseAttackValue + _attackDamageToEnemy) * (int)_attackTypes);
            
            activeEntity.MoveAction();
            EventBus<OnHealthChanged>.Fire(new OnHealthChanged());
            EventBus<OnTakeDamage>.Fire(new OnTakeDamage
            {
                Stat =  _stat
            });
        }
    }
}