using Interfaces;
using UnityEngine;

namespace Attack.Persona
{
    [CreateAssetMenu(fileName = "PiercePersonaAttack", menuName = "ScriptableObjets/PersonaAttack/PiercePersonaAttack")]
    public class PiercePersonaAttack : PersonaBaseAttack
    {
        public override void AttackAction(IMove deactiveEntity, IMove activeEntity)
        {
            base.AttackAction(deactiveEntity, activeEntity);
            Debug.Log(Stat + " Attack! " + "Total Damage: " + _entityBaseSo.BaseAttackValue + _attackDamageToEnemy);
        }
    }
}