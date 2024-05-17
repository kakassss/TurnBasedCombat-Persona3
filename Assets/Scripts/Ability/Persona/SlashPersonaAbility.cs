using Interfaces;
using UnityEngine;

namespace Ability.Persona
{
    [CreateAssetMenu(fileName = "SlashPersonaAbility", menuName = "ScriptableObjets/PersonaAbility/SlashPersonaAbility")]
    public class SlashPersonaAbility : PersonaBaseAbility
    {
        public override void AbilityAction(IMove activeEntity,IMove deactiveEntity)
        {
            Debug.Log("This persona has " + Stat + " ability");
        }
    }
}