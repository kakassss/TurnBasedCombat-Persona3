using System;
using Enums;
using Interfaces;
using Interfaces.Stats;
using UnityEngine;

namespace Defence.Shadow
{
    public abstract class ShadowBaseDefence : EntityBaseDefenceData, IShadowDefence
    {
        public Stat Stat => _stat;
        public DefenceTypes DefenceTypes => _defenceTypes;
        public virtual void DefenceAction(IMove deactiveEntity, Stat stat)
        {
            stat = _stat;
            
            Debug.Log("current stat damaged " + stat);
            switch (DefenceTypes)
            {
                case DefenceTypes.Normal:
                    Debug.Log("This Shadow has " + Stat + " " + DefenceTypes + " defence");
                    break;
                case DefenceTypes.Weakness:
                    Debug.Log("This Shadow has " + Stat + " " + DefenceTypes + " defence");
                    break;
                case DefenceTypes.Reflect:
                    Debug.Log("This Shadow has " + Stat + " " + DefenceTypes + " defence");
                    break;
                case DefenceTypes.Resistance:
                    Debug.Log("This Shadow has " + Stat + " " + DefenceTypes + " defence");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}