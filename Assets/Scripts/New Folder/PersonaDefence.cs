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
    public override void Defence()
    {
        
    }

    public Stat Stat => Stat.Slash;
}
public class PiercePersonaDefence : PersonaDefence
{
    public override void Defence()
    {
        
    }
    
    public Stat Stat => Stat.Pierce;
}


public class StrikePersonaDefence : PersonaDefence
{
    public override void Defence()
    {

    }
    
    public Stat Stat => Stat.Strike;
}