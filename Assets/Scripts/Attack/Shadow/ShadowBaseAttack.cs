using System.Collections.Generic;
using Enums;
using Interfaces;
using Interfaces.Stats;
using SignalBus;
using UnityEngine;

namespace Attack.Shadow
{
    public abstract class ShadowBaseAttack : EntityBaseAttackData, IShadowAttack
    {
        public Stat Stat => _stat;
        public AttackTypes AttackTypes => _attackTypes;
        public string AttackName => _attackName;
        public int AttackDamageToItself => _attackDamageToItself;
        
        private int _randomPersona;
        public virtual void AttackAction(IMove activeEntity,List<IMove> allDeactiveEntities)
        {
            _randomPersona = Helper.GetRandomNumber(0, allDeactiveEntities.Count);
            var targetPersona = allDeactiveEntities[_randomPersona];
            
            //activeEntity.entity.TakeDamageUsingAttack(_attackDamageToItself);
            targetPersona.entity.TakeDamage((activeEntity.entity.entityBaseSo.BaseAttackValue + _attackDamageToEnemy) * (int)_attackTypes);
            
            Debug.Log("Shadow " + Stat + " Attack! " + "Total Damage: " + (activeEntity.entity.entityBaseSo.BaseAttackValue + _attackDamageToEnemy) * (int)_attackTypes);
            
            activeEntity.MoveAction();
            EventBus<OnHealthChanged>.Fire(new OnHealthChanged());
            EventBus<OnTakeDamage>.Fire(new OnTakeDamage());
        }

    }
}