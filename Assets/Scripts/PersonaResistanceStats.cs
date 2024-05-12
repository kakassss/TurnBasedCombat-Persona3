using UnityEngine;

[CreateAssetMenu(fileName = "PersonaResistanceStats", menuName = "ScriptableObjets/PersonaResistanceStats")]
public class PersonaResistanceStats : PersonaStatsFactory
{
    [Header("BasicAttack Resistance")]
    public bool SlashResistance;
    public bool StrikeResistance;
    public bool PierceResistance;
    
    [Header("Skills Resistance")]
    public bool FireResistance;
    public bool IceResistance;
    public bool ElectricityResistance;
    public bool WindResistance;
    public bool LightResistance;
    public bool DarkResistance;
    
    protected override void AddAllPersonaStatTypes()
    {
        AllStatsTypes.Add(SlashResistance);
        AllStatsTypes.Add(StrikeResistance);
        AllStatsTypes.Add(PierceResistance);
        AllStatsTypes.Add(FireResistance);
        AllStatsTypes.Add(IceResistance);
        AllStatsTypes.Add(ElectricityResistance);
        AllStatsTypes.Add(WindResistance);
        AllStatsTypes.Add(LightResistance);
        AllStatsTypes.Add(DarkResistance);
    }

    public override void SetStatType()
    {
        _stat = StatTypes.Resistance;
    }
}
