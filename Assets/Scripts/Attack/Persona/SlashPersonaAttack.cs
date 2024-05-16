using Interfaces;
using UnityEngine;

namespace Attack.Persona
{
    [CreateAssetMenu(fileName = "SlashPersonaAttack", menuName = "ScriptableObjets/PersonaAttack/SlashPersonaAttack")]
    public class SlashPersonaAttack : PersonaBaseAttack
    {
        public override void AttackAction(IMove deactiveEntity,IMove activeEntity)
        {
            deactiveEntity.entity.TakeDamage(_entityBaseSo.BaseAttackValue + _attackDamageToEnemy);
            Debug.Log(Stat + " Attack! " + "Total Damage: " + _entityBaseSo.BaseAttackValue + _attackDamageToEnemy);
        }
    }
}