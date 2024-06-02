using System.Collections.Generic;
using System.Linq;
using Interfaces;
using SignalBus;
using UnityEngine;

namespace Battle.UI.Health
{
    public class ShadowHealthUI : BattleBaseHealthUI
    {
        private readonly string ShadowHealth = "ShadowHealth: ";
        private EventBinding<OnShadowDeadUI> _onShadowDeadUI;

        private List<IMove> _allAliveShadows = new List<IMove>();
        
        protected override void OnEnable()
        {
            base.OnEnable();
            EnableEventBus();
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            DisableEventBus();
        }

        private void EnableEventBus()
        {
            _onShadowDeadUI = new EventBinding<OnShadowDeadUI>(OnShadowDeadUI);
            EventBus<OnShadowDeadUI>.Subscribe(_onShadowDeadUI);
        }
        
        private void DisableEventBus()
        {
            EventBus<OnShadowDeadUI>.Unsubscribe(_onShadowDeadUI);
        }
    
        protected override void SetUIData()
        {
            _allAliveShadows.Clear();
            foreach (var shadow in _battleDataProvider.GetAllShadows().Where(shadow => shadow.entity.IsDead == false))
            {
                _allAliveShadows.Add(shadow);
            }
        }
    
        protected override void SetUI()
        {
            SetUIData();

            for (int i = 0; i < _battleDataProvider.GetAllShadows().Count; i++)
            {
                _entityHealthTexts[i].gameObject.SetActive(false);
            }
            
            for (int i = 0; i < _allAliveShadows.Count; i++)
            {
                _entityHealthTexts[i].gameObject.SetActive(true);
                _entityHealthTexts[i].text = ShadowHealth + _allAliveShadows[i].entity.CurrentHealth.ToString();
            }
        }
        
        private void OnShadowDeadUI(OnShadowDeadUI dead)
        {
            CloseTextAtIndex(dead.activeShadowIndex);
        }
    }
}
