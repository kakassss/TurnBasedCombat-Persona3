using SignalBus;
using UnityEngine;

namespace Battle.UI.Action.AllOutAttack
{
    public class BattleActionAllOutAttackUI : MonoBehaviour
    {
        [SerializeField] private GameObject _allOutUI;
        
        private EventBinding<OnAllOutAttack> _onAllOutAttack;

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
            _onAllOutAttack = new EventBinding<OnAllOutAttack>(OpenUI);
            EventBus<OnAllOutAttack>.Subscribe(_onAllOutAttack);
        }
        
        private void DisableEventBus()
        {
            EventBus<OnAllOutAttack>.Unsubscribe(_onAllOutAttack);
        }

        private void OpenUI()
        {
            _allOutUI.gameObject.SetActive(true);
        }
    }
}
