using SelectShadow;
using SignalBus;

namespace Battle.UI.Defence
{
    public class ShadowDefenceUI : BattleBaseDefenceUI
    {
        public override void TakeDamage(OnTakeDamage deactiveEntity)
        {
            var currentShadowTextIndex = SelectTargetShadow.CurrentShadowIndex;
            var takenDamageStat = deactiveEntity.Stat;
        
            OpenActiveEntityText(currentShadowTextIndex);
            SetActiveEntityText(takenDamageStat.ToString(),currentShadowTextIndex);
        }
    }
}
