using Interfaces;
using UnityEngine;

namespace Attack.Shadow
{
    [CreateAssetMenu(fileName = "SlashShadowAttack", menuName = "ScriptableObjets/ShadowAttack/SlashShadowAttack")]
    public class SlashShadowAttack : ShadowBaseAttack
    {
        public override void AttackAction(IMove activeEntity,IMove deactiveEntity)
        {
            base.AttackAction(activeEntity,deactiveEntity);
        }
    }
}