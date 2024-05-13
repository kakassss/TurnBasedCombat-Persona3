using UnityEngine;

[CreateAssetMenu(fileName = "SlashPersonaAbility", menuName = "ScriptableObjets/PersonaAbility/SlashPersonaAbility")]
public class SlashPersonaAbility : PersonaBaseAbility
{
    public override void AbilityAction()
    {
        Debug.Log("This persona has " + Stat + " ability");
    }

    public Stat Stat => Stat.Slash;
}