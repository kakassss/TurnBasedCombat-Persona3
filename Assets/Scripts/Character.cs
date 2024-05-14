using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private CharacterBase _characterBase;

    [Header("Stats")] 
    [SerializeField] private List<CharacterBaseAbilities> _characterBaseAbilities;
    
    
    
    private int _currentHealth;
    private int _currentMana;
    
    

}