﻿using System.Collections.Generic;
using Enums;
using Interfaces;
using Interfaces.Stats;
using SignalBus;

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
            var damage = (activeEntity.entity.entityBaseSo.BaseAttackValue + _attackDamageToEnemy) * (int)_attackTypes;
            
            activeEntity.entity.TakeDamageUsingAttack(_attackDamageToItself);
            targetPersona.entity.TakeDamage(damage);
            
            EventBus<OnPersonaTakeDamage>.Fire(new OnPersonaTakeDamage
            {
                Stat =  _stat,
                persona = targetPersona,
                shadow = activeEntity,
                totalDamage = damage,
                currentPersona = _randomPersona
            });
            activeEntity.MoveAction();
        }

    }
}