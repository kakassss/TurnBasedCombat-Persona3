﻿using UnityEngine;

namespace Defence.Persona
{
    [CreateAssetMenu(fileName = "StrikePersonaDefence", menuName = "ScriptableObjets/PersonaDefence/StrikePersonaDefence")]
    public class StrikePersonaDefence : PersonaBaseDefence
    {
        public override void DefenceAction()
        {
            Debug.Log("This persona has " + Stat + " " + DefenceTypes + " defence");
        }
    }
}