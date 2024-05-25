using Battle.Action;
using SignalBus;
using UnityEngine;

namespace Battle.UI.Defence
{
    public class ShadowDefenceUI : BattleBaseDefenceUI
    {
        private EventBinding<OnShadowDefenceActionUI> _shadowDefenceAction;
        private EventBinding<OnShadowTurn> _shadowTurn;
        
        protected override void EnableEventBus()
        {
            _shadowTurn = new EventBinding<OnShadowTurn>(ShadowTurn);
            EventBus<OnShadowTurn>.Subscribe(_shadowTurn);
            
            _shadowDefenceAction = new EventBinding<OnShadowDefenceActionUI>(TakeDamage);
            EventBus<OnShadowDefenceActionUI>.Subscribe(_shadowDefenceAction);
        }

        protected override void DisableEventBus()
        {
            EventBus<OnShadowTurn>.Unsubscribe(_shadowTurn);
            EventBus<OnShadowDefenceActionUI>.Unsubscribe(_shadowDefenceAction);
        }

        private void ShadowTurn()
        {
            CloseAllTexts();
        }
        
        private void TakeDamage(OnShadowDefenceActionUI deactiveEntity)
        {
            var currentShadowTextIndex = BattleDataProvider.ActiveShadowIndex;
            
            OpenActiveEntityText(currentShadowTextIndex);
            SetActiveEntityText(deactiveEntity.defenceType, currentShadowTextIndex);
        }
    }
}
