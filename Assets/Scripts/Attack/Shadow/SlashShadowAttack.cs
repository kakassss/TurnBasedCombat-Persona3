using Interfaces;
using UnityEngine;

namespace Attack.Shadow
{
    [CreateAssetMenu(fileName = "SlashShadowAttack", menuName = "ScriptableObjets/ShadowAttack/SlashShadowAttack")]
    public class SlashShadowAttack : ShadowBaseAttack
    {
        public override void AttackAction(IMove deactiveEntity, IMove activeEntity)
        {
            base.AttackAction(deactiveEntity, activeEntity);
            Debug.Log(Stat + " Attack! " + "Total Damage: " + _entityBaseSo.BaseAttackValue + _attackDamageToEnemy);
        }
    }
}