using System.Collections.Generic;
using Ability.Character;
using Attack.Character;
using Defence.Character;
using UnityEngine;

public class Character : MonoBehaviour
{
    //[SerializeField] private CharacterBase _characterBase;
    
    private int _currentHealth;
    private int _currentMana;
    
    [Header("Stats")] 
    public List<CharacterBaseAbilities> _characterBaseAbilities;
    public List<CharacterBaseDefence> _characterDefences;
    public List<CharacterBaseAttack> _characterBaseAttacks;
    
    
}