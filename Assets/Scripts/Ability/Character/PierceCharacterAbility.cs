using UnityEngine;

[CreateAssetMenu(fileName = "PierceCharacterAbility", menuName = "ScriptableObjets/CharacterAbility/PierceCharacterAbility")]
public class PierceCharacterAbility : CharacterBaseAbilities
{
    public override void AbilityAction()
    {
        Debug.Log("This persona has " + Stat + " ability");
    }
}