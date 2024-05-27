using System;
using Battle.Action;
using SignalBus;
using UnityEngine;

namespace SelectShadow
{
    public class SelectTargetShadow : MonoBehaviour
    {
        private const int MinShadowCount = 0;
    
        private BattleDataProvider _battleDataProvider;

        private int _shadowTotalCount;
        private int _shadowIndex;
        private void Awake()
        {
            _battleDataProvider = FindObjectOfType<BattleDataProvider>();
        }

        private void Start()
        {
            SetData();
        }

        private void SetData()
        {
            _shadowTotalCount = _battleDataProvider.GetShadowCount();
        }

        private void Update()
        {
            if (_battleDataProvider.GetActiveEntity() != _battleDataProvider.GetActivePersona()) return;

            HandleInput(KeyCode.UpArrow, -1);
            HandleInput(KeyCode.DownArrow, 1);
        }

        private void HandleInput(KeyCode key, int direction)
        {
            if (!Input.GetKeyDown(key)) return;

            _shadowIndex += direction;
            
            if (_shadowIndex > _shadowTotalCount)
            {
                _shadowIndex = MinShadowCount;
            }

            if (_shadowIndex < MinShadowCount)
            {
                _shadowIndex = _shadowTotalCount;
            }
            BattleDataProvider.ActiveShadowIndex  = _shadowIndex;
            EventBus<OnShadowTargetChanged>.Fire(new OnShadowTargetChanged
            {
                ActiveShadowIndex = _shadowIndex
            });
        }
    }
}
