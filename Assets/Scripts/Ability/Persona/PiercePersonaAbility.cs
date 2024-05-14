using UnityEngine;

namespace Ability.Persona
{
    [CreateAssetMenu(fileName = "PiercePersonaAbility", menuName = "ScriptableObjets/PersonaAbility/PiercePersonaAbility")]
    public class PiercePersonaAbility : PersonaBaseAbility
    {
        public override void AbilityAction()
        {
            Debug.Log("This persona has " + Stat + " ability");
        }
    }
}