using System.Collections.Generic;
using UnityEngine;

public abstract class PersonaStatsFactory : ScriptableObject, IPersonaStatInit
{
    [HideInInspector] public List<bool> AllStatsTypes;
    [HideInInspector] public List<bool> PersonaStats;

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
            if (stat) PersonaStats.Add(stat);
        }
    }
    protected abstract void AddAllPersonaStatTypes();
    
}
