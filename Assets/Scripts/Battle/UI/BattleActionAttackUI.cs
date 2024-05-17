using System.Collections;
using System.Collections.Generic;
using Interfaces;
using TMPro;
using UnityEngine;

public class BattleActionAttackUI : BattleBaseActionUI
{
    public override void SetActionUI()
    {
        InstantiateActionButton(_battleDataProvider.GetActiveEntity());
    }

    public override void InstantiateActionButton(IMove actions)
    {
        var listAction = actions.entity.EntityAttacks;

        foreach (var action in listAction)
        {
            var currentActionButton = Instantiate(_actionButton, _actionGroup.transform);
            
            currentActionButton.onClick.AddListener(() =>
            {
                action.Attack.AttackAction(
                    _battleDataProvider.GetActiveEntity(),
                    _battleDataProvider.GetDeactiveEntity());
            });

            currentActionButton.GetComponentInChildren<TextMeshProUGUI>().text = action.Attack.AttackName;
        }
        
        
    }
}
