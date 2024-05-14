using UnityEngine;

namespace Ability.Character
{
    [CreateAssetMenu(fileName = "StrikeCharacterAbility", menuName = "ScriptableObjets/CharacterAbility/StrikeCharacterAbility")]
    public class StrikeCharacterAbility : CharacterBaseAbilities
    {
        public override void AbilityAction()
        {
            Debug.Log("This persona has " + Stat + " ability");
        }
    }
}