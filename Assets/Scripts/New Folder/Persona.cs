using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persona : MonoBehaviour
{
    public int Health;
    public int Level;
    public int Mana;
    public int Name;

    private Reflect reflectPersona = new Reflect("ReflectPersona",22);
    private Weakness weaknessPersona = new Weakness("WeaknessPersona",33);

    private List<IPersonaAttack> allPersona = new List<IPersonaAttack>();

    public List<PersonaAbilities> PersonaAbilitiesList = new List<PersonaAbilities>();
    
    
    private void Update()
    {
        Checkstat();
    }

    private StrikeStat _strikeStat = new StrikeStat(true, true, false, false);

    private void Checkstat()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _strikeStat.Defence();
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
public class Stats
{
    public bool Weakness;
    public bool Resistance;
    public bool Normal;
    public bool Reflect;


    public Stats(bool weakness, bool resistance, bool normal, bool reflect)
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

public class StrikeStat : Stats, IPersonaDefence
{
    public StrikeStat(bool weakness, bool resistance, bool normal, bool reflect) : base(weakness, resistance, normal, reflect)
    {
    }

    public void Defence()
    {
        if (Resistance)
        {
            Debug.Log("This Persona Has resistance to Strike Attacks");
        }
        if (Weakness)
        {
            Debug.Log("This Persona Has Weakness to Strike Attacks");
        }
        if (Normal)
        {
            Debug.Log("This Persona has no effect to Strike Attacks");
        }
        if (Reflect)
        {
            Debug.Log("This Persona Has Reflect to Strike Attacks");
        }
    }
}

public class PersonaStats
{
    
}

public class PersonaAbilities
{
    
    
    
    
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