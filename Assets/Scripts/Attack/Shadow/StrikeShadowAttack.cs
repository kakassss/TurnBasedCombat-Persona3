using Interfaces;
using UnityEngine;

namespace Attack.Shadow
{
    [CreateAssetMenu(fileName = "StrikeShadowAttack", menuName = "ScriptableObjets/ShadowAttack/StrikeShadowAttack")]
    public class StrikeShadowAttack : ShadowBaseAttack
    {
        public override void AttackAction(IMove deactiveEntity,IMove activeEntity)
        {
            deactiveEntity.entity.TakeDamage(_entityBaseSo.BaseAttackValue + _attackDamageToEnemy);
            activeEntity.entity.TakeDamageUsingAttack(_attackDamageToItself);
            Debug.Log(Stat + " Attack! " + "Total Damage: " + _entityBaseSo.BaseAttackValue + _attackDamageToEnemy);
        }
    }
}