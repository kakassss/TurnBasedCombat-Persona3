using UnityEngine;

public abstract class PersonaBaseAbility : ScriptableObject,IPersonaAbility
{
    [SerializeField] protected Stat _stat;
    public string AbilityName;
    public Sprite AbilitySprite;
    
    public virtual void AbilityAction()
    {
        
    }

    public Stat Stat => _stat;
}