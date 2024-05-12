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
        PersonaStats.AddRange(AllStatsTypes.Where(skill => skill == this));
    }
    
    protected abstract void AddAllPersonaStatTypes();
    
}
