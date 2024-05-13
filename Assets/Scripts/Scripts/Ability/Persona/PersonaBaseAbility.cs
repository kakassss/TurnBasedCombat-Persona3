using UnityEngine;

public abstract class PersonaBaseAbility : EntityBaseAbilities,IPersonaAbility
{
    public Stat Stat => _stat;
    
    public virtual void AbilityAction()
    {
        
    }
}