using UnityEngine;

[CreateAssetMenu(fileName = "PiercePersonaAbility", menuName = "ScriptableObjets/PersonaAbility/PiercePersonaAbility")]
public class PiercePersonaAbility : PersonaBaseAbility
{
    public override void AbilityAction()
    {
        Debug.Log("This persona has " + Stat + " ability");
    }

    public Stat Stat => Stat.Pierce;
}