using UnityEngine;

public class PersonaAbility : IPersonaAbility
{
    public string AbilityName;
    public Sprite AbilitySprite;
    
    public virtual void AbilityAction()
    {
        
    }

    public Stat Stat { get; }
}

public class SlashPersonaAbility : PersonaAbility
{
    public override void AbilityAction()
    {
        Debug.Log("This persona has " + Stat + " ability");
        
    }

    public Stat Stat => Stat.Slash;
}