using Battle.Action;
using SignalBus;
using UnityEngine;

namespace Battle.UI.Defence
{
    public class PersonaDefenceUI : BattleBaseDefenceUI
    {
        private EventBinding<OnPersonaDefenceActionUI> _personaDefenceAction;
        private EventBinding<OnPersonaTurn> _personaTurn;
        
    
        protected override void EnableEventBus()
        {
            _personaTurn = new EventBinding<OnPersonaTurn>(PersonaTurn);
            EventBus<OnPersonaTurn>.Subscribe(_personaTurn);
            
            _personaDefenceAction = new EventBinding<OnPersonaDefenceActionUI>(TakeDamage);
            EventBus<OnPersonaDefenceActionUI>.Subscribe(_personaDefenceAction);
        }

        protected override void DisableEventBus()
        {
            EventBus<OnPersonaTurn>.Unsubscribe(_personaTurn);
            EventBus<OnPersonaDefenceActionUI>.Unsubscribe(_personaDefenceAction);
        }

        private void PersonaTurn()
        {
            CloseAllTexts();
        }
        
        private void TakeDamage(OnPersonaDefenceActionUI personaUIData)
        {
            var currentPersonaIndex = personaUIData.activePersonaIndex;
            
            OpenActiveEntityText(currentPersonaIndex);
            SetActiveEntityText(personaUIData.defenceType, currentPersonaIndex);
        }
    }
}
