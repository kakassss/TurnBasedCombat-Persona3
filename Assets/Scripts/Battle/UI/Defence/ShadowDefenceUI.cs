using SelectShadow;
using SignalBus;

namespace Battle.UI.Defence
{
    public class ShadowDefenceUI : BattleBaseDefenceUI
    {
        private EventBinding<OnShadowTurn> _shadowTurn;
        
        
        protected override void OnEnable()
        {
            base.OnEnable();
            EnableEventBus();
        }
        protected virtual void OnDisable()
        {
            base.OnDisable();
            DisableEventBus();
        }
    
        private void EnableEventBus()
        {
            _shadowTurn = new EventBinding<OnShadowTurn>(ShadowTurn);
            EventBus<OnShadowTurn>.Subscribe(_shadowTurn);
        }

        private void DisableEventBus()
        {
            EventBus<OnShadowTurn>.Unsubscribe(_shadowTurn);
        }

        private void ShadowTurn()
        {
            CloseAllTexts();
        }
        
        protected override void TakeDamage(OnDefenceActionUI deactiveEntity)
        {
            var currentShadowTextIndex = SelectTargetShadow.CurrentShadowIndex;
            
            OpenActiveEntityText(currentShadowTextIndex);
            SetActiveEntityText(deactiveEntity.defenceType, currentShadowTextIndex);
        }
    }
}
