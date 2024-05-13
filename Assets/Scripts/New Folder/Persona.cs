using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    
}

public class CharacterAbilities : Character, ICharacterAbilities
{
    public void AbilityAction()
    {
        Debug.Log("This persona has " + Ability + " ability");
    }

    public Abilities Ability => Abilities.Dark;
}

public interface ICharacterAbilities : IAbility
{
    
}

public interface IAbility
{
    void AbilityAction();
    Abilities Ability { get; }
}

public class Persona : MonoBehaviour
{
    public int Health;
    public int Level;
    public int Mana;
    public int Name;

    private Reflect reflectPersona = new Reflect("ReflectPersona",22);
    private Weakness weaknessPersona = new Weakness("WeaknessPersona",33);

    private List<IPersonaAttack> allPersona = new List<IPersonaAttack>();

    public List<PersonaAbility> PersonaAbilitiesList = new List<PersonaAbility>();

    private List<IPersonaDefence> personaDefence = new List<IPersonaDefence>();
    private void Awake()
    {
        personaDefence.Add(_slashPersonaDefence);
        personaDefence.Add(_strikePersonaDefence);
        personaDefence.Add(_piercePersonaDefence);
        
        
        _slashPersonaAbility.AbilityAction();

        if (_characterAbilities.Ability == _slashPersonaAbility.Ability)
        {
            Debug.Log("Wassap Dog1");
        }
        else
        {
            Debug.Log("Wassap Dog2");
        }
    }

    private void Update()
    {
        Checkstat();
    }

    private StrikePersonaDefence _strikePersonaDefence = new StrikePersonaDefence(true, true, false, false);
    private SlashPersonaDefence _slashPersonaDefence = new SlashPersonaDefence(true, true, true, true);
    private PiercePersonaDefence _piercePersonaDefence = new PiercePersonaDefence(true, true, true, true);

    private SlashPersonaAbility _slashPersonaAbility = new SlashPersonaAbility();
    private CharacterAbilities _characterAbilities = new CharacterAbilities();
    
    private void Checkstat()
    {
        if (!Input.GetKeyDown(KeyCode.Space)) return;
        foreach (var defence in personaDefence)
        {
            defence.Defence();
        }
    }
}
/*
 * [Header("BasicAttacks")]
    public bool Slash;
    public bool Strike;
    public bool Pierce;
    
    [Header("Skills")]
    public bool Fire;
    public bool Ice;
    public bool Electricity;
    public bool Wind;
    public bool Light;
    public bool Dark;
 */


public interface IPersonaDefence
{
    void Defence();
}

public interface IPersonaAbility : IAbility
{
    
}

public class PersonaDefence
{
    public bool Weakness;
    public bool Resistance;
    public bool Normal;
    public bool Reflect;


    protected PersonaDefence(bool weakness, bool resistance, bool normal, bool reflect)
    {
        Weakness = weakness;
        Resistance = resistance;
        Normal = normal;
        Reflect = reflect;
    }
    /*
     *  nötr, reflect, resistance, weakness
     *  herbir personada bu 9 stat karşı yukarıdaki 4 olaydan biri var
     *
     */
}

public class SlashPersonaDefence : PersonaDefence, IPersonaDefence
{
    public SlashPersonaDefence(bool weakness, bool resistance, bool normal, bool reflect) : base(weakness, resistance, normal, reflect)
    {
    }

    public void Defence()
    {
        if (Resistance) Debug.Log("This Persona Has resistance to Slash Attacks");
        if (Weakness) Debug.Log("This Persona Has Weakness to Slash Attacks");
        if (Normal) Debug.Log("This Persona has no effect to Slash Attacks");
        if (Reflect) Debug.Log("This Persona Has Reflect to Slash Attacks");
    }
}
public class PiercePersonaDefence : PersonaDefence, IPersonaDefence
{
    public PiercePersonaDefence(bool weakness, bool resistance, bool normal, bool reflect) : base(weakness, resistance, normal, reflect)
    {
    }

    public void Defence()
    {
        if (Resistance) Debug.Log("This Persona Has resistance to Pierce Attacks");
        if (Weakness) Debug.Log("This Persona Has Weakness to Pierce Attacks");
        if (Normal) Debug.Log("This Persona has no effect to Pierce Attacks");
        if (Reflect) Debug.Log("This Persona Has Reflect to Pierce Attacks");
    }
}


public class StrikePersonaDefence : PersonaDefence, IPersonaDefence
{
    public StrikePersonaDefence(bool weakness, bool resistance, bool normal, bool reflect) : base(weakness, resistance, normal, reflect)
    {
    }

    public void Defence()
    {
        if (Resistance) Debug.Log("This Persona Has resistance to Strike Attacks");
        if (Weakness) Debug.Log("This Persona Has Weakness to Strike Attacks");
        if (Normal) Debug.Log("This Persona has no effect to Strike Attacks");
        if (Reflect) Debug.Log("This Persona Has Reflect to Strike Attacks");
    }
}



public enum Abilities
{
    Slash,
    Strike,
    Pierce,
    Fire,
    Ice,
    Electricity,
    Wind,
    Light,
    Dark
}

public class SlashPersonaAbility : PersonaAbility
{
    public override void AbilityAction()
    {
        Debug.Log("This persona has " + Ability + " ability");
        
    }
    public Abilities Ability { get; }
}

public class PersonaAbility : IAbility
{
    public string AbilityName;
    public Sprite AbilitySprite;
    
    public virtual void AbilityAction()
    {
        
    }

    public Abilities Ability { get; }
}

public class Reflect : IPersonaFireAttack,IPersonaIceAttack
{
    public string _name;
    public int _level;

    public Reflect(string name, int level)
    {
        _name = name;
        _level = level;
    }
    
    public void Attack()
    {
        Debug.Log("Reflect to IceAttack");
    }
}

public class Weakness : IPersonaFireAttack,IPersonaIceAttack
{
    public string _name;
    public int _level;

    public Weakness(string name, int level)
    {
        _name = name;
        _level = level;
    }
    
    public void Attack()
    {
        Debug.Log("Weakness to IceAttack");
    }
}