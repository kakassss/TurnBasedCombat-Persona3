using System.Collections.Generic;
using SignalBus;
using UnityEngine;

namespace Battle.UI.GameWin
{
    public class BattleGameWinActionUI : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _openUI;
        [SerializeField] private List<GameObject> _closeUI;
        
        private EventBinding<OnGameWin> _onShadowHealth;
        
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
            _onShadowHealth = new EventBinding<OnGameWin>(SetGameWinUI);
            EventBus<OnGameWin>.Subscribe(_onShadowHealth);
        }
        
        private void DisableEventBus()
        {
            EventBus<OnGameWin>.Unsubscribe(_onShadowHealth);
        }

        private void SetGameWinUI()
        {
            foreach (var openUI in _openUI)
            {
                openUI.SetActive(true);
            }

            foreach (var closeUI in _closeUI)
            {
                closeUI.SetActive(false);
            }
        }
    }
}
