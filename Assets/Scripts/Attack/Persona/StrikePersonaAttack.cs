using Interfaces;
using UnityEngine;

namespace Attack.Persona
{
    [CreateAssetMenu(fileName = "StrikePersonaAttack", menuName = "ScriptableObjets/PersonaAttack/StrikePersonaAttack")]
    public class StrikePersonaAttack : PersonaBaseAttack
    {
        public override void AttackAction(IMove activeEntity,IMove deactiveEntity)
        {
            base.AttackAction(activeEntity,deactiveEntity);
            Debug.Log("Persona " + Stat + " Attack! " + "Total Damage: " + activeEntity.entity.entityBaseSo.BaseAttackValue + _attackDamageToEnemy);
        }
    }
}