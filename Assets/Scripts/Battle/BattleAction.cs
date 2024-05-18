using System;
using UnityEngine;
using UnityEngine.Serialization;

public class BattleAction : MonoBehaviour
{
    [SerializeField] private BattleDataProvider _battleDataProvider;
    [SerializeField] private BattleDataAction _battleDataAction;

    private EventBinding<OnMoveActionTurn> _moveAction;

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
        _moveAction = new EventBinding<OnMoveActionTurn>(SetActionTurn);
        EventBus<OnMoveActionTurn>.Subscribe(_moveAction);
    }

    private void DisableEventBus()
    {
        EventBus<OnMoveActionTurn>.Unsubscribe(_moveAction);
    }
    
    private void SetActionTurn()
    {
        _battleDataAction.Swap();
        Debug.Log("Action Swap");
    }
    
    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     var activeEntity = _battleDataProvider.GetActiveEntity().entity;
        //     var deactiveEntity = _battleDataProvider.GetDeactiveEntity().entity;
        //     
        //     activeEntity.MoveAction();
        //     _battleDataAction.Swap();
        //     //_battleData.
        // }
    }
}
