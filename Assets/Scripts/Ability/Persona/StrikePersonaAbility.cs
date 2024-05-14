using UnityEngine;

[CreateAssetMenu(fileName = "StrikePersonaAbility", menuName = "ScriptableObjets/PersonaAbility/StrikePersonaAbility")]
public class StrikePersonaAbility : PersonaBaseAbility
{
    public override void AbilityAction()
    {
        Debug.Log("This persona has " + Stat + " ability");
    }
    
}