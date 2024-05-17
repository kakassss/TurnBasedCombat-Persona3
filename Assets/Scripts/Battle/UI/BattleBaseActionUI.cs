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

    protected virtual void Start()
    {
        SetActionUI();
    }

    protected virtual void SetActionUI()
    {
        InstantiateActionButton(_battleDataProvider.GetActiveEntity());
    }
    protected abstract void InstantiateActionButton(IMove actions);
}


