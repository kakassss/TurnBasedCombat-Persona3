using System.Collections.Generic;
using Ability.Shadow;
using Attack.Shadow;
using Defence.Shadow;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    //[SerializeField] private CharacterBase _characterBase;
    
    private int _currentHealth;
    private int _currentMana;
    
    [Header("Stats")] 
    public List<ShadowBaseAbilities> _characterBaseAbilities;
    public List<ShadowBaseDefence> _characterDefences;
    public List<ShadowBaseAttack> _characterBaseAttacks;
    
    
}