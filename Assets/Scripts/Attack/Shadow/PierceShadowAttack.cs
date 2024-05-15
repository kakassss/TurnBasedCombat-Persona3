﻿using UnityEngine;

namespace Attack.Shadow
{
    [CreateAssetMenu(fileName = "PierceShadowAttack", menuName = "ScriptableObjets/ShadowAttack/PierceShadowAttack")]
    public class PierceShadowAttack : ShadowBaseAttack
    {
        public override void AttackAction()
        {
            Debug.Log(Stat + " Attack!");
        }
    }
}