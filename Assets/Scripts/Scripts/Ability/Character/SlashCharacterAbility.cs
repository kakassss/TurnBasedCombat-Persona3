using UnityEngine;

[CreateAssetMenu(fileName = "SlashCharacterAbility", menuName = "ScriptableObjets/CharacterAbility/SlashCharacterAbility")]
public class SlashCharacterAbility : CharacterBaseAbilities
{
    public override void AbilityAction()
    {
        Debug.Log("This persona has " + Stat + " ability");
    }
}