using SelectShadow;
using SignalBus;

namespace Battle.UI.Defence
{
    public class ShadowDefenceUI : BattleBaseDefenceUI
    {
        protected override void TakeDamage(OnDefenceActionUI deactiveEntity)
        {
            var currentShadowTextIndex = SelectTargetShadow.CurrentShadowIndex;
            
            OpenActiveEntityText(currentShadowTextIndex);
            SetActiveEntityText(deactiveEntity.attackName, currentShadowTextIndex);
        }
    }
}
