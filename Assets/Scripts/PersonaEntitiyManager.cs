using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonaEntitiyManager : MonoBehaviour
{
    [SerializeField] private PersonaBaseStats personaBaseStats;


    private void Awake()
    {
        PrintCurrentPersonaStats();
    }

    private void PrintCurrentPersonaStats()
    {
        personaBaseStats.InitPersonaStats();
        
        Debug.Log("---------------------------Base Stats------------------"); 
        Debug.Log(personaBaseStats.name); 
        Debug.Log(personaBaseStats.Health); 
        Debug.Log(personaBaseStats.Level); 
        Debug.Log(personaBaseStats.Health);
        Debug.Log(personaBaseStats.Mana); 
        Debug.Log("--------------------------------------------------------");

        foreach (var stat in personaBaseStats._allStats)
        {
            Debug.Log("Current Stat " + stat.GetStat());
            foreach (var specialStat in stat.PersonaStats)
            {
                Debug.Log(specialStat);
            } 
        }        
    }
    
}
