public class PersonaDefence : IPersonaDefence
{
    // public bool Weakness;
    // public bool Resistance;
    // public bool Normal;
    // public bool Reflect;
    //
    //
    // protected PersonaDefence(bool weakness, bool resistance, bool normal, bool reflect)
    // {
    //     Weakness = weakness;
    //     Resistance = resistance;
    //     Normal = normal;
    //     Reflect = reflect;
    //}
    /*
     *  nötr, reflect, resistance, weakness
     *  herbir personada bu 9 stat karşı yukarıdaki 4 olaydan biri var
     *
     */
    public virtual void Defence()
    {
        
    }

    public Stat Stat { get; }
}

public class SlashPersonaDefence : PersonaDefence
{
    // public SlashPersonaDefence(bool weakness, bool resistance, bool normal, bool reflect) : base(weakness, resistance, normal, reflect)
    // {
    // }
    
    public override void Defence()
    {
        // if (Resistance) Debug.Log("This Persona Has resistance to Slash Attacks");
        // if (Weakness) Debug.Log("This Persona Has Weakness to Slash Attacks");
        // if (Normal) Debug.Log("This Persona has no effect to Slash Attacks");
        // if (Reflect) Debug.Log("This Persona Has Reflect to Slash Attacks");
    }

    public Stat Stat => Stat.Slash;
}
public class PiercePersonaDefence : PersonaDefence
{
    // public PiercePersonaDefence(bool weakness, bool resistance, bool normal, bool reflect) : base(weakness, resistance, normal, reflect)
    // {
    // }

    public override void Defence()
    {
        // if (Resistance) Debug.Log("This Persona Has resistance to Pierce Attacks");
        // if (Weakness) Debug.Log("This Persona Has Weakness to Pierce Attacks");
        // if (Normal) Debug.Log("This Persona has no effect to Pierce Attacks");
        // if (Reflect) Debug.Log("This Persona Has Reflect to Pierce Attacks");
    }
}


public class StrikePersonaDefence : PersonaDefence
{
    // public StrikePersonaDefence(bool weakness, bool resistance, bool normal, bool reflect) : base(weakness, resistance, normal, reflect)
    // {
    // }

    public override void Defence()
    {
        // if (Resistance) Debug.Log("This Persona Has resistance to Strike Attacks");
        // if (Weakness) Debug.Log("This Persona Has Weakness to Strike Attacks");
        // if (Normal) Debug.Log("This Persona has no effect to Strike Attacks");
        // if (Reflect) Debug.Log("This Persona Has Reflect to Strike Attacks");
    }
}