using System.Collections.Generic;
using Ability.Persona;
using Attack.Persona;
using Defence.Persona;
using UnityEngine;


public class Persona : MonoBehaviour
{
    //[SerializeField] private PersonaBase personaBase;
    
    private int _currentHealth;
    private int _currentMana;

    public List<PersonaBaseAbility> _personaBaseAbilities;
    public List<PersonaBaseAttack> _personaBaseAttacks;
    public List<PersonaBaseDefence> _personaBaseDefences;
    

}