using UnityEngine;

[CreateAssetMenu(fileName = "PersonaAttackTypesStats", menuName = "ScriptableObjets/PersonaAttackTypesStats")]
public class PersonaAttackTypesStats : PersonaStatsFactory
{
    [Header("BasicAttacks")]
    public bool Slash;
    public bool Strike;
    public bool Pierce;
    
    [Header("Skills")]
    public bool Fire;
    public bool Ice;
    public bool Electricity;
    public bool Wind;
    public bool Light;
    public bool Dark;
    
    protected override void AddAllPersonaStatTypes()
    {
        AllStatsTypes.Add(Slash);
        AllStatsTypes.Add(Strike);
        AllStatsTypes.Add(Pierce);
        AllStatsTypes.Add(Fire);
        AllStatsTypes.Add(Ice);
        AllStatsTypes.Add(Electricity);
        AllStatsTypes.Add(Wind);
        AllStatsTypes.Add(Light);
        AllStatsTypes.Add(Dark);
    }

    public override void SetStatType()
    {
        _stat = StatTypes.Attack;
    }
}
