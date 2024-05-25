using System;
using System.Collections.Generic;
using BaseEntity;
using Battle.Action;
using Interfaces;
using SignalBus;
using TMPro;
using UnityEngine;

namespace Battle.UI.Defence
{
    public abstract class BattleBaseDefenceUI : MonoBehaviour
    {
        [SerializeField] protected List<TextMeshProUGUI> _defenceTexts;
        protected BattleDataProvider _battleDataProvider;
        
        private void Awake()
        {
            _battleDataProvider = FindObjectOfType<BattleDataProvider>();
        }

        protected void OnEnable()
        {
            EnableEventBus();
        }

        protected void OnDisable()
        {
            DisableEventBus();
        }

        protected void SetActiveEntityText(string text,int index)
        {
            _defenceTexts[index].text = text;
        }
    
        protected void OpenActiveEntityText(int index)
        {
            _defenceTexts[index].gameObject.SetActive(true);
        }

        protected void CloseAllTexts()
        {
            foreach (var text in _defenceTexts)
            {
                text.gameObject.SetActive(false);
            }
        }

        protected abstract void EnableEventBus();
        protected abstract void DisableEventBus();
    }
}
