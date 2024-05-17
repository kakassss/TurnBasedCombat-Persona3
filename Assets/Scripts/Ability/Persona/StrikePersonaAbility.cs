using Interfaces;
using UnityEngine;

namespace Ability.Persona
{
    [CreateAssetMenu(fileName = "StrikePersonaAbility", menuName = "ScriptableObjets/PersonaAbility/StrikePersonaAbility")]
    public class StrikePersonaAbility : PersonaBaseAbility
    {
        public override void AbilityAction(IMove activeEntity,IMove deactiveEntity)
        {
            Debug.Log("This persona has " + Stat + " ability");
        }
    
    }
}