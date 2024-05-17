using System;
using Enums;
using Interfaces;
using UnityEngine;

namespace Defence.Persona
{
    [CreateAssetMenu(fileName = "PiercePersonaDefence", menuName = "ScriptableObjets/PersonaDefence/PiercePersonaDefence")]
    public class PiercePersonaDefence : PersonaBaseDefence
    {
        public override void DefenceAction(IMove deactiveEntity)
        {
            
        }
    }
}