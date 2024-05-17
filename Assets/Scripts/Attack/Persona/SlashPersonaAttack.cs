using Interfaces;
using UnityEngine;

namespace Attack.Persona
{
    [CreateAssetMenu(fileName = "SlashPersonaAttack", menuName = "ScriptableObjets/PersonaAttack/SlashPersonaAttack")]
    public class SlashPersonaAttack : PersonaBaseAttack
    {
        public override void AttackAction(IMove activeEntity,IMove deactiveEntity)
        {
            base.AttackAction(activeEntity,deactiveEntity);
            Debug.Log("Persona " + Stat + " Attack! " + "Total Damage: " + activeEntity.entity.entityBaseSo.BaseAttackValue + _attackDamageToEnemy);
        }
    }
}