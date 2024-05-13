using UnityEngine;

public abstract class CharacterBaseAbilities : ScriptableObject, ICharacterAbilities
{
    public void AbilityAction()
    {
        Debug.Log("This persona has " + Stat + " ability");
    }

    public Stat Stat { get; }
}