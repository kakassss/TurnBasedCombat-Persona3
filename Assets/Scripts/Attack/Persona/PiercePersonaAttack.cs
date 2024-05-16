using Interfaces;
using UnityEngine;

namespace Attack.Persona
{
    [CreateAssetMenu(fileName = "PiercePersonaAttack", menuName = "ScriptableObjets/PersonaAttack/PiercePersonaAttack")]
    public class PiercePersonaAttack : PersonaBaseAttack
    {
        public override void AttackAction(IMove deactiveEntity,IMove activeEntity)
        {
            
        }
    }
}