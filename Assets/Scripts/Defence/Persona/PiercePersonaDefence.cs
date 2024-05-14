using System;
using Enums;
using UnityEngine;

namespace Defence.Persona
{
    [CreateAssetMenu(fileName = "PiercePersonaDefence", menuName = "ScriptableObjets/PersonaDefence/PiercePersonaDefence")]
    public class PiercePersonaDefence : PersonaBaseDefence
    {
        public override void DefenceAction()
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