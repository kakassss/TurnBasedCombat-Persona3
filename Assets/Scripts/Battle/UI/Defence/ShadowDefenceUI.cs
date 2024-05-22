using SelectShadow;
using SignalBus;

namespace Battle.UI.Defence
{
    public class ShadowDefenceUI : BattleBaseDefenceUI
    {
        public override void TakeDamage(OnDefenceActionUI deactiveEntity)
        {
            var currentShadowTextIndex = SelectTargetShadow.CurrentShadowIndex;
            
            OpenActiveEntityText(currentShadowTextIndex);
            SetActiveEntityText(deactiveEntity.attackName,currentShadowTextIndex);
        }
    }
}
