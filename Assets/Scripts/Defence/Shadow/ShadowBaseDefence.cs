﻿using System;
using Battle.Action;
using Enums;
using Interfaces;
using Interfaces.Stats;
using SignalBus;
using UnityEngine;

namespace Defence.Shadow
{
    public abstract class ShadowBaseDefence : EntityBaseDefenceData, IShadowDefence
    {
        public Stat Stat => _stat;
        public DefenceTypes DefenceTypes => _defenceTypes;
        
        private string _defence;
        public virtual void DefenceAction(IMove activeEntity,IMove deactiveEntity, Stat stat,int totalDamage)
        {
            var otherStat = stat;

            if (otherStat == _stat)
            {
                switch (DefenceTypes)
                {
                    case DefenceTypes.Normal:
                        _defence = "Normal";
                        break;
                    case DefenceTypes.Weakness:
                        _defence = "Weakness";
                        var damage = totalDamage / 2;
                       deactiveEntity.entity.TakeDamage(damage);
                        break;
                    case DefenceTypes.Reflect:
                        _defence = "Reflect";
                        activeEntity.entity.TakeDamage(totalDamage);
                        break;
                    case DefenceTypes.Resistance:
                        _defence = "Resistance";
                        deactiveEntity.entity.Heal(totalDamage);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            
            EventBus<OnHealthChanged>.Fire(new OnHealthChanged());
            EventBus<OnShadowDefenceActionUI>.Fire(new OnShadowDefenceActionUI
            {
                defenceType = _defence,
                activeShadowIndex = BattleDataProvider.ActiveShadowIndex
            });
            
        }
    }
}