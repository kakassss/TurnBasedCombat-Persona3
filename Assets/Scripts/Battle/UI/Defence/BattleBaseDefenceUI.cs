using System.Collections.Generic;
using Battle.Action;
using SignalBus;
using TMPro;
using UnityEngine;

namespace Battle.UI.Defence
{
    public abstract class BattleBaseDefenceUI : MonoBehaviour
    {
        [SerializeField] protected List<TextMeshProUGUI> _defenceTexts;
        protected BattleDataProvider _battleDataProvider;
        private EventBinding<OnDefenceActionUI> _defenceAction;

        private void Awake()
        {
            _battleDataProvider = FindObjectOfType<BattleDataProvider>();
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
            _defenceAction = new EventBinding<OnDefenceActionUI>(TakeDamage);
            EventBus<OnDefenceActionUI>.Subscribe(_defenceAction);
        }

        private void DisableEventBus()
        {
            EventBus<OnDefenceActionUI>.Unsubscribe(_defenceAction);
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
    
        public abstract void TakeDamage(OnDefenceActionUI deactiveEntity);
    }
}
