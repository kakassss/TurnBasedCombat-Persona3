using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Persona : MonoBehaviour
{
    [SerializeField] private PersonaBase personaBase;
    
    private int _currentHealth;
    private int _currentMana;

    [SerializeField] private List<PersonaBaseAbility> _personaBaseAbilities;

    private void Awake()
    {
    }

    private void Abilities()
    {
        foreach (var ability in _personaBaseAbilities)
        {
            ability.AbilityAction();
            
            Debug.Log(ability.Stat);
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