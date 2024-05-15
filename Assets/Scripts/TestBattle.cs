using System;
using System.Collections;
using System.Collections.Generic;
using Enums;
using UnityEngine;
using UnityEngine.Serialization;

public class TestBattle : MonoBehaviour
{
    [SerializeField] private Persona persona;
    [FormerlySerializedAs("enemy")] [FormerlySerializedAs("character")] [SerializeField] private Shadow shadow;


    private void Awake()
    {
        CharacterAttack();
    }

    private void CharacterAttack()
    { 
        var currentCharacter = shadow._characterBaseAttacks[0];
        var targetPersona = persona._personaBaseDefences[0];
        
        if (currentCharacter.Stat == targetPersona.Stat)
        {
            Debug.Log("Persona has defence system for " + currentCharacter.Stat  + " attack");
            
            currentCharacter.Attack();
            targetPersona.DefenceAction();
            
            
        }
        
    }
    
}
