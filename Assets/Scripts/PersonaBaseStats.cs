using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "PersonaStats", menuName = "ScriptableObjets/PersonaStats")]
public class PersonaBaseStats : ScriptableObject
{
    [Header("Stats")]
    public List<PersonaStatsFactory> _allStats;
    
    [Header("Prefab")]
    public GameObject PersonaPrefab;
    
    [Header("BaseStats")]
    public string name;
    public int Level;
    public int Health;
    public int Mana;

    public void InitPersonaStats()
    {
        foreach (var stat in _allStats)
        {
            stat.SetPersonaStats();
            stat.SetStatType();
        }
    }

    public PersonaStatsFactory GetDesiredStatType(StatTypes stat)
    {
        foreach (var stats in _allStats.Where(stats => stat == stats.GetStat()))
        {
            return stats;
        }

        return null;
    }
}
