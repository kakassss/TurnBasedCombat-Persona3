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
        
        var resistanceStat = personaBaseStats.GetDesiredStatType(StatTypes.Resistance);
        Debug.Log(resistanceStat.name);
        Debug.Log(resistanceStat.ValidStats[0]);
        
        /*
         * sorun şu;
         * Karşı tarafdan ya da player tarafından gelen hasar tipini nasıl anlayacaksın
         * yani stringden o mu bu mu şu mu diye karşılastırmak manasız ve ağır yük
         * bool fire gibi variablelarımız var ama manasız booleanlardan ibaretler, neyi temsil ettiğini anlamıyoruz
         * her birine class uydurmak fazla maliyetli olabilir,
         * günün sonunda bu kurdugumuz SO yapısını bu maliyetden kaçmak için kurmuştuk
         * 
         */
        //var fireStat = allstats[0].GetStat()
    }
    
}
