using System;
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
        public virtual void DefenceAction(IMove deactiveEntity, Stat stat)
        {
            stat = _stat;
            switch (DefenceTypes)
            {
                case DefenceTypes.Normal:
                    _defence = "Normal";
                    break;
                case DefenceTypes.Weakness:
                    _defence = "Weakness";
                    break;
                case DefenceTypes.Reflect:
                    _defence = "Reflect";
                    break;
                case DefenceTypes.Resistance:
                    _defence = "Resistance";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            EventBus<OnDefenceActionUI>.Fire(new OnDefenceActionUI
            {
                attackName = _defence
            });
            
        }
    }
}