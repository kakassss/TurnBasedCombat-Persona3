using UnityEngine;

[CreateAssetMenu(fileName = "PersonaReflectStats", menuName = "ScriptableObjets/PersonaReflectStats")]
public class PersonaReflectStats : PersonaStatsFactory
{
    [Header("BasicAttack Reflect")]
    public bool SlashReflect;
    public bool StrikeReflect;
    public bool PierceReflect;
    
    [Header("Skills Reflect")]
    public bool FireReflect;
    public bool IceReflect;
    public bool ElectricityReflect;
    public bool WindReflect;
    public bool LightReflect;
    public bool DarkReflect;
    
    protected override void AddAllPersonaStatTypes()
    {
        AllStatsTypes.Add(SlashReflect);
        AllStatsTypes.Add(StrikeReflect);
        AllStatsTypes.Add(PierceReflect);
        AllStatsTypes.Add(FireReflect);
        AllStatsTypes.Add(IceReflect);
        AllStatsTypes.Add(ElectricityReflect);
        AllStatsTypes.Add(WindReflect);
        AllStatsTypes.Add(LightReflect);
        AllStatsTypes.Add(DarkReflect);
    }

    public override void SetStatType()
    {
        _stat = StatTypes.Reflect;
    }
}
