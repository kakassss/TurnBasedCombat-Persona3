using UnityEngine;

public abstract class PersonaBaseAbility : ScriptableObject,IPersonaAbility
{
    public Stat Stat => _stat;
    
    public string AbilityName;
    public Sprite AbilitySprite;
    
    [SerializeField] protected Stat _stat;
    
    public virtual void AbilityAction()
    {
        
    }
}