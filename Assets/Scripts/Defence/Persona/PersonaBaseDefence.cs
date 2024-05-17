using System;
using Enums;
using Interfaces;
using UnityEngine;

namespace Defence.Persona
{
    public abstract class PersonaBaseDefence : EntityBaseDefenceData, IPersonaDefence
    {
        public Stat Stat => _stat;
        public DefenceTypes DefenceTypes => _defenceTypes;

        public virtual void DefenceAction(IMove deactiveEntity)
        {
            switch (DefenceTypes)
            {
                case DefenceTypes.Normal:
                    Debug.Log("This persona has " + Stat + " " + DefenceTypes + " defence");
                    break;
                case DefenceTypes.Weakness:
                    Debug.Log("This persona has " + Stat + " " + DefenceTypes + " defence");
                    break;
                case DefenceTypes.Reflect:
                    Debug.Log("This persona has " + Stat + " " + DefenceTypes + " defence");
                    break;
                case DefenceTypes.Resistance:
                    Debug.Log("This persona has " + Stat + " " + DefenceTypes + " defence");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}