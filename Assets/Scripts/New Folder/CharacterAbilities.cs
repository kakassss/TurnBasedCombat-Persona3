using UnityEngine;

public class CharacterAbilities : Character, ICharacterAbilities
{
    public void AbilityAction()
    {
        Debug.Log("This persona has " + Stat + " ability");
    }

    public Stat Stat => Stat.Dark;
}