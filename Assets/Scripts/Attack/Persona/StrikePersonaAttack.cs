﻿using Interfaces;
using UnityEngine;

namespace Attack.Persona
{
    [CreateAssetMenu(fileName = "StrikePersonaAttack", menuName = "ScriptableObjets/PersonaAttack/StrikePersonaAttack")]
    public class StrikePersonaAttack : PersonaBaseAttack
    {
        public override void AttackAction(IMove deactiveEntity,IMove activeEntity)
        {
        }
    }
}