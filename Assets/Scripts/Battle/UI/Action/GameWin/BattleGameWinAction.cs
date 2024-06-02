using System.Linq;
using Battle.Action;
using SignalBus;
using UnityEngine;

namespace Battle.UI.Action.GameWin
{
    public class BattleGameWinAction : MonoBehaviour
    {
        [SerializeField] private BattleDataProvider _battleDataProvider;
        private EventBinding<OnHealthChanged> _onShadowHealth;
        private EventBinding<OnShadowDeadUI> _onShadowDead;
        private void OnEnable()
        {
            EnableEventBus();
        }

        private void OnDisable()
        {
            DisableEventBus();
        }

        private void EnableEventBus()
        {
            _onShadowHealth = new EventBinding<OnHealthChanged>(GameWinAction);
            EventBus<OnHealthChanged>.Subscribe(_onShadowHealth);
            
            _onShadowDead = new EventBinding<OnShadowDeadUI>(GameWinAction);
            EventBus<OnShadowDeadUI>.Subscribe(_onShadowDead);
        }
        
        private void DisableEventBus()
        {
            EventBus<OnHealthChanged>.Unsubscribe(_onShadowHealth);
            EventBus<OnShadowDeadUI>.Unsubscribe(_onShadowDead);
        }

        private void GameWinAction()
        {
            var allShadow = _battleDataProvider.GetAllShadows();
            
            if (allShadow.Any(shadow => shadow.entity.GetHealth() > 0)) return;
            
            EventBus<OnGameWin>.Fire(new OnGameWin());
        }
    }
}
