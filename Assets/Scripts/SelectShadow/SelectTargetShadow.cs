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
            if(_battleDataProvider.GetActiveEntity() != _battleDataProvider.GetActivePersona()) return;
        
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                _shadowIndex = Mathf.Clamp(_shadowIndex +1, MinShadowCount, _shadowTotalCount);
                CurrentShadowIndex = _shadowIndex;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                _shadowIndex = Mathf.Clamp(_shadowIndex  - 1, MinShadowCount, _shadowTotalCount);
                CurrentShadowIndex = _shadowIndex;
            }
        }
    }
}
