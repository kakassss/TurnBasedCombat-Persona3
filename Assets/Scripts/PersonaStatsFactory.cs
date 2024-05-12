using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class PersonaStatsFactory : ScriptableObject, IPersonaStatInit
{
    public Dictionary<StatTypes, bool> dic;
    [HideInInspector] public List<bool> AllStatsTypes;
    [HideInInspector] public List<bool> ValidStats;

    public StatTypes _stat;
    public virtual void SetPersonaStats()
    {
        AddAllPersonaStatTypes();
        GetPersonaStatTypes();
    }

    public virtual void SetStatType()
    {
        
    }


    public StatTypes GetStat()
    {
        return _stat;
    }
    
    private void GetPersonaStatTypes()
    {
        foreach (var stat in AllStatsTypes)
        {
            if (stat) ValidStats.Add(stat);
        }
    }
    protected abstract void AddAllPersonaStatTypes();
    
}
