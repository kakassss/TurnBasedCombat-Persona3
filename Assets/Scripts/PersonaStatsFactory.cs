using System.Collections.Generic;
using System.Linq;
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
        foreach (var currentStat in AllStatsTypes)
        {
            if (currentStat == true)
            {
                PersonaStats.Add(currentStat);
            }
        }
    }
    protected abstract void AddAllPersonaStatTypes();
    
}
