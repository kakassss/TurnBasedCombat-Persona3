using System.Collections.Generic;
using Ability.Character;
using Defence.Character;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private CharacterBase _characterBase;

    [Header("Stats")] 
    [SerializeField] private List<CharacterBaseAbilities> _characterBaseAbilities;

    [SerializeField] private List<CharacterBaseDefence> _characterDefences;
    
    
    private int _currentHealth;
    private int _currentMana;

    private void Awake()
    {
        foreach (var defence in _characterDefences)
        {
            Debug.Log(defence.DefenceTypes + " " + defence.Stat);
        }
    }


}