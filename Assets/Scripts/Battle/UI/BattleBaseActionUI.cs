using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class BattleBaseActionUI : MonoBehaviour
{
    [SerializeField] protected BattleDataProvider _battleDataProvider;
    [SerializeField] protected Transform _actionGroup;
    [SerializeField] protected Button _actionButton;

    protected virtual void Start()
    {
        SetActionUI();
    }

    public abstract void SetActionUI();
    public abstract void InstantiateActionButton(IMove actions);
}


