using UnityEngine;

[CreateAssetMenu(fileName = "PersonaResistanceStats", menuName = "ScriptableObjets/PersonaResistanceStats")]
public class PersonaResistanceStats : PersonaStatsFactory
{
    [Header("BasicAttack Resistance")]
    public bool Slash;
    public bool Strike;
    public bool Pierce;
    
    [Header("Skill Resistance")]
    public bool Fire;
    public bool Ice;
    public bool Electricity;
    public bool Wind;
    public bool Light;
    public bool Dark;
    
    protected override void AddAllPersonaStatTypes()
    {
        // AllStatsTypes.Add(Slash);
        // AllStatsTypes.Add(Strike);
        // AllStatsTypes.Add(Pierce);
        // AllStatsTypes.Add(Fire);
        // AllStatsTypes.Add(Ice);
        // AllStatsTypes.Add(Electricity);
        // AllStatsTypes.Add(Wind);
        // AllStatsTypes.Add(Light);
        // AllStatsTypes.Add(Dark);
    }

    public override void SetStatType()
    {
        _stat = StatTypes.Resistance;
    }
}
