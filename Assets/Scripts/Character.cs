using System;
using System.Collections.Generic;
using Defence.Character;
using Defence.Persona;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private CharacterBase _characterBase;

    [Header("Stats")] 
    [SerializeField] private List<CharacterBaseAbilities> _characterBaseAbilities;

    [SerializeField] private List<CharacterDefence> _characterDefences;
    
    
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