using SelectShadow;
using SignalBus;

namespace Battle.UI.Defence
{
    public class PersonaDefenceUI : BattleBaseDefenceUI
    {
        public override void TakeDamage(OnTakeDamage deactiveEntity)
        {
            // var currentShadowTextIndex = SelectTargetShadow.CurrentShadowIndex;
            // var allShadows = _battleDataProvider.GetAllShadows();
            // var activeDefence = allShadows[currentShadowTextIndex].entity.EntityDefences;
            // var takenDamageStat = deactiveEntity.Stat;
            //
            // OpenActiveShadowText(currentShadowTextIndex);
            // SetActiveShadowText(takenDamageStat.ToString(),currentShadowTextIndex);
        }
    }
}
