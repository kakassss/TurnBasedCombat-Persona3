using System;
using Battle.Action;
using UnityEngine;

namespace SelectShadow
{
    public class SelectTargetShadow : MonoBehaviour
    {
        public static int CurrentShadowIndex = 0;
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
            _shadowTotalCount = _battleDataProvider.GetCurrentEntityCount();
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
            
            //_shadowIndex = Mathf.Clamp(_shadowIndex + direction, MinShadowCount, _shadowTotalCount); // belki -1 gelebilir sınırı bi zorla
            CurrentShadowIndex = _shadowIndex;
        }
    }
}
