using UnityEngine;

[CreateAssetMenu(fileName = "PersonaWeaknessStats", menuName = "ScriptableObjets/PersonaWeaknessStats")]
public class PersonaWeaknessStats : PersonaStatsFactory
{
    [Header("BasicAttack Weakness")]
    public bool SlashWeakness;
    public bool StrikeWeakness;
    public bool PierceWeakness;
    
    [Header("Skills Weakness")]
    public bool FireWeakness;
    public bool IceWeakness;
    public bool ElectricityWeakness;
    public bool WindWeakness;
    public bool LightWeakness;
    public bool DarkWeakness;
    
    protected override void AddAllPersonaStatTypes()
    {
        AllStatsTypes.Add(SlashWeakness);
        AllStatsTypes.Add(StrikeWeakness);
        AllStatsTypes.Add(PierceWeakness);
        AllStatsTypes.Add(FireWeakness);
        AllStatsTypes.Add(IceWeakness);
        AllStatsTypes.Add(ElectricityWeakness);
        AllStatsTypes.Add(WindWeakness);
        AllStatsTypes.Add(LightWeakness);
        AllStatsTypes.Add(DarkWeakness);
    }

    public override void SetStatType()
    {
        _stat = StatTypes.Weakness;
    }
}
