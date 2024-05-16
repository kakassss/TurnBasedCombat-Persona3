using Interfaces;
using UnityEngine;

namespace Attack.Shadow
{
    [CreateAssetMenu(fileName = "StrikeShadowAttack", menuName = "ScriptableObjets/ShadowAttack/StrikeShadowAttack")]
    public class StrikeShadowAttack : ShadowBaseAttack
    {
        public override void AttackAction(IMove deactiveEntity, IMove activeEntity)
        {
            base.AttackAction(deactiveEntity, activeEntity);
            Debug.Log(Stat + " Attack! " + "Total Damage: " + _entityBaseSo.BaseAttackValue + _attackDamageToEnemy);
        }
    }
}