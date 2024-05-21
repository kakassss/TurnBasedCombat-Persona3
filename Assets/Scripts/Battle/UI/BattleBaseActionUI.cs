using System.Collections.Generic;
using Interfaces;
using SignalBus;
using UnityEngine;
using UnityEngine.UI;

namespace Battle.UI
{
    public abstract class BattleBaseActionUI : MonoBehaviour
    {
        protected const string BUTTON_INIT_NAME = "Button_";
        protected const string HEALTH = "HP";
        protected const string MANA = "MP";
        protected const string SPACE = " ";
    
        [SerializeField] protected BattleDataProvider _battleDataProvider;
        [SerializeField] protected List<Button> _actionButtons;
        [SerializeField] protected List<GameObject> _actionUIElements;
        
        private EventBinding<OnMoveActionTurn> _moveAction;
    
        protected virtual void OnEnable()
        {
            EnableEventBus();
        }

        private void Start()
        {
            SetActionUI();
        }

        private void OnDisable()
        {
            DisableEventBus();
        }

        private void EnableEventBus()
        {
            _moveAction = new EventBinding<OnMoveActionTurn>(SetActionUI);
            EventBus<OnMoveActionTurn>.Subscribe(_moveAction);
        }

        private void DisableEventBus()
        {
            EventBus<OnMoveActionTurn>.Unsubscribe(_moveAction);
        }
    
        private void SetActionUI()
        {
            SetUIElementsState(ActiveEntity() != true);

            ResetButtons();
            InstantiateActionButton(_battleDataProvider.GetActivePersona());
        }

        private void SetUIElementsState(bool state)
        {
            foreach (var ui in _actionUIElements)
            {
                ui.SetActive(state);
            }
        }
        
        private void ResetButtons()
        {
            foreach (var button in _actionButtons)
            {
                button.gameObject.SetActive(false);
                button.onClick.RemoveAllListeners();
            }
        }

        private bool ActiveEntity()
        {
            return _battleDataProvider.GetActiveEntity() == _battleDataProvider.GetActiveShadow();
        }
        
        protected abstract void InstantiateActionButton(IMove actions);
    }
}


