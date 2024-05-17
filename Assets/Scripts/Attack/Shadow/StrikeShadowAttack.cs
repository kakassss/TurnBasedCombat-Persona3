using Interfaces;
using UnityEngine;

namespace Attack.Shadow
{
    [CreateAssetMenu(fileName = "StrikeShadowAttack", menuName = "ScriptableObjets/ShadowAttack/StrikeShadowAttack")]
    public class StrikeShadowAttack : ShadowBaseAttack
    {
        public override void AttackAction(IMove activeEntity,IMove deactiveEntity)
        {
            base.AttackAction(activeEntity,deactiveEntity);
            Debug.Log("Shadow " + Stat + " Attack! " + "Total Damage: " + activeEntity.entity.entityBaseSo.BaseAttackValue + _attackDamageToEnemy);
        }
    }
}