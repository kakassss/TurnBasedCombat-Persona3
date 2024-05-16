using Interfaces;
using UnityEngine;

namespace Attack.Persona
{
    [CreateAssetMenu(fileName = "PiercePersonaAttack", menuName = "ScriptableObjets/PersonaAttack/PiercePersonaAttack")]
    public class PiercePersonaAttack : PersonaBaseAttack
    {
        public override void AttackAction(IMove activeEntity,IMove deactiveEntity)
        {
            base.AttackAction(activeEntity,deactiveEntity);
            Debug.Log(Stat + " Attack! " + "Total Damage: " + activeEntity.entity.entityBaseSo.BaseAttackValue + _attackDamageToEnemy);
        }
    }
}