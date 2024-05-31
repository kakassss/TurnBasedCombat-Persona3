using System;
using System.Linq;
using Battle.Action;
using SignalBus;
using UnityEngine;

namespace Attack.AllOutAttack.AllOutAttackAction
{
    public class AllOutAttackAction : MonoBehaviour
    {
        [SerializeField] private BattleDataProvider _battleDataProvider;
        
        private EventBinding<OnCanAllOutAttack> _onCanAllOutAttack;
        
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
            _onCanAllOutAttack = new EventBinding<OnCanAllOutAttack>(EnableAllOutAttack);
            EventBus<OnCanAllOutAttack>.Subscribe(_onCanAllOutAttack);
        }
        
        private void DisableEventBus()
        {
            EventBus<OnCanAllOutAttack>.Unsubscribe(_onCanAllOutAttack);
        }
        
        private void EnableAllOutAttack()
        {
            var allShadows = _battleDataProvider.GetAllShadows();
            
            if (allShadows.Any(shadow => shadow.entity.IsDisable == false)) return;
            
            EventBus<OnAllOutAttack>.Fire(new OnAllOutAttack());
        }
    }
}
