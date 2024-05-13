using UnityEngine;

public abstract class PersonaBaseAbility : ScriptableObject,IPersonaAbility
{
    public string AbilityName;
    public Sprite AbilitySprite;
    
    public virtual void AbilityAction()
    {
        
    }

    public Stat Stat { get; }
}