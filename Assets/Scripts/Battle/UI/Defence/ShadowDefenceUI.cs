using SignalBus;
using UnityEngine;

namespace Battle.UI.Defence
{
    public class ShadowDefenceUI : BattleBaseDefenceUI
    {
        private EventBinding<OnShadowDefenceActionUI> _shadowDefenceAction;
        private EventBinding<OnShadowAllOutDefenceActionUI> _shadowAllOutDefenceAction;
        private EventBinding<OnShadowTurn> _shadowTurn;
        
        protected override void EnableEventBus()
        {
            _shadowTurn = new EventBinding<OnShadowTurn>(ShadowTurn);
            EventBus<OnShadowTurn>.Subscribe(_shadowTurn);
            
            _shadowDefenceAction = new EventBinding<OnShadowDefenceActionUI>(TakeDamage);
            EventBus<OnShadowDefenceActionUI>.Subscribe(_shadowDefenceAction);

            _shadowAllOutDefenceAction = new EventBinding<OnShadowAllOutDefenceActionUI>(TakeAllOutDamage);
            EventBus<OnShadowAllOutDefenceActionUI>.Subscribe(_shadowAllOutDefenceAction);
        }

        protected override void DisableEventBus()
        {
            EventBus<OnShadowTurn>.Unsubscribe(_shadowTurn);
            EventBus<OnShadowDefenceActionUI>.Unsubscribe(_shadowDefenceAction);
            EventBus<OnShadowAllOutDefenceActionUI>.Unsubscribe(_shadowAllOutDefenceAction);
        }

        private void ShadowTurn()
        {
            CloseAllTexts();
        }
        
        private void TakeDamage(OnShadowDefenceActionUI shadowUIData)
        {
            var currentShadowTextIndex = shadowUIData.activeShadowIndex;
            OpenActiveEntityText(currentShadowTextIndex);
            SetActiveEntityText(shadowUIData.defenceType, currentShadowTextIndex);
        }

        private void TakeAllOutDamage(OnShadowAllOutDefenceActionUI shadowUIData)
        {
            CloseAllTexts();
        }
        
    }
}
