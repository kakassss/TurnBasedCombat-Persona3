using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using UnityEngine.UI;

public abstract class BattleBaseActionUI : MonoBehaviour
{
    protected const string BUTTON_INIT_NAME = "Button_";
    protected const string HEALTH = "HP";
    protected const string MANA = "MP";
    protected const string SPACE = " ";
    
    [SerializeField] protected BattleDataProvider _battleDataProvider;
    [SerializeField] protected Transform _actionGroup;
    [SerializeField] protected Button _actionButton;

    [SerializeField] protected List<Button> _actionButtons;
    
    private EventBinding<OnMoveActionTurn> _moveAction;

    private void OnEnable()
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
    
    protected virtual void SetActionUI()
    {
        ResetButtons();
        InstantiateActionButton(_battleDataProvider.GetActiveEntity());
    }

    private void ResetButtons()
    {
        foreach (var button in _actionButtons)
        {
            button.gameObject.SetActive(false);
            button.onClick.RemoveAllListeners();
        }
    }
    
    protected abstract void InstantiateActionButton(IMove actions);
}


