using SignalBus;
using UnityEngine;

namespace Battle.Action
{
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
        }
    }
}
