using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Persona : MonoBehaviour
{
    private int _currentHealth;
    private int _currentMana;
    [SerializeField] private PersonaBase personaBase;
    
    private List<IPersonaAttack> allPersona = new List<IPersonaAttack>();

    public List<PersonaAbility> PersonaAbilitiesList = new List<PersonaAbility>();

    private List<IPersonaDefence> personaDefence = new List<IPersonaDefence>();
    private void Awake()
    {
        // personaDefence.Add(_slashPersonaDefence);
        // personaDefence.Add(_strikePersonaDefence);
        // personaDefence.Add(_piercePersonaDefence);
        _currentHealth = personaBase.Health;
        _currentMana = personaBase.Mana;
        
        _slashPersonaAbility.AbilityAction();

        check();
    }

    private void Update()
    {
        Checkstat();
    }

    // private StrikePersonaDefence _strikePersonaDefence = new StrikePersonaDefence(true, true, false, false);
    // private SlashPersonaDefence _slashPersonaDefence = new SlashPersonaDefence(true, true, true, true);
    // private PiercePersonaDefence _piercePersonaDefence = new PiercePersonaDefence(true, true, true, true);

    private SlashPersonaAbility _slashPersonaAbility = new SlashPersonaAbility();
    private SlashPersonaDefence _slashPersonaDefence = new SlashPersonaDefence();

    private void check()
    {

        if (_slashPersonaAbility.Stat == _slashPersonaAbility.Stat)
        {
            Debug.Log("dog");
        }
        
    }
    
    
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