using System;
using System.Collections.Generic;
using Battle.Action;
using SignalBus;
using TMPro;
using UnityEngine;

namespace Battle.UI.Health
{
    public abstract class BattleBaseHealthUI : MonoBehaviour
    {
        [SerializeField] protected BattleDataProvider _battleDataProvider;
        [SerializeField] protected List<TextMeshProUGUI> _entityHealthTexts;
    
        private EventBinding<OnHealthChanged> _takeDamage;
        
        private void Start()
        {
            SetUIData();
            SetUI();
        }

        protected virtual void OnEnable()
        {
            EnableEventBus();
        }

        protected virtual void OnDisable()
        {
            DisableEventBus();
        }

        private void EnableEventBus()
        {
            _takeDamage = new EventBinding<OnHealthChanged>(SetUI);
            EventBus<OnHealthChanged>.Subscribe(_takeDamage);
        }

        private void DisableEventBus()
        {
            EventBus<OnHealthChanged>.Unsubscribe(_takeDamage);
        }

        protected void CloseTextAtIndex(int index)
        {
            _entityHealthTexts[index].gameObject.SetActive(false);
        }
        
        protected void CloseTexts()
        {
            foreach (var text in _entityHealthTexts)
            {
                text.gameObject.SetActive(false);
            }
        }
        
        protected abstract void SetUIData();
        protected abstract void SetUI();
    }
}
