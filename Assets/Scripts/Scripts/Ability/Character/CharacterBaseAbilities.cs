using UnityEngine;

public abstract class CharacterBaseAbilities : ScriptableObject, ICharacterAbilities
{
    public Stat Stat => _stat;
    
    public Sprite AbilitySprite;
    public string AbilityName;
    
    [SerializeField] protected Stat _stat;
    
    public void AbilityAction()
    {
        Debug.Log("This persona has " + Stat + " ability");
    }

}