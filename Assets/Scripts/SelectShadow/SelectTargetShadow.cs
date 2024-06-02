using System.Linq;
using Battle.Action;
using SignalBus;
using UnityEngine;

namespace SelectShadow
{
    public class SelectTargetShadow : MonoBehaviour
    {
        private const int MinShadowCount = 0;
        
        private EventBinding<OnShadowDeadUI> _onShadowDead;
        private BattleDataProvider _battleDataProvider;

        private int _shadowTotalCount = 0;
        private int _shadowIndex;
        private void Awake()
        {
            _battleDataProvider = FindObjectOfType<BattleDataProvider>();
        }

        private void Start()
        {
            SetData();
        }
        
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
            _onShadowDead = new EventBinding<OnShadowDeadUI>(SetData);
            EventBus<OnShadowDeadUI>.Subscribe(_onShadowDead);
        }
        
        private void DisableEventBus()
        {
            EventBus<OnShadowDeadUI>.Unsubscribe(_onShadowDead);
        }
        
        private void SetData()
        {
            _shadowTotalCount = 0;
            foreach (var shadow in _battleDataProvider.GetAllShadows().Where(shadow => shadow.entity.IsDead == false))
            {
                _shadowTotalCount++;
            }
        }

        private void Update()
        {
            if (_battleDataProvider.GetActiveEntity() != _battleDataProvider.GetActivePersona()) return;
            EventBus<OnShadowTargetChanged>.Fire(new OnShadowTargetChanged
            {
                ActiveShadowIndex = _shadowIndex
            });
            
            
            HandleInput(KeyCode.UpArrow, -1);
            HandleInput(KeyCode.DownArrow, 1);
        }

        private void HandleInput(KeyCode key, int direction)
        {
            if (!Input.GetKeyDown(key)) return;

            _shadowIndex += direction;
            
            if (_shadowIndex >= _shadowTotalCount)
            {
                _shadowIndex = MinShadowCount;
            }

            if (_shadowIndex < MinShadowCount)
            {
                _shadowIndex = _shadowTotalCount-1;
            }
            
            BattleDataProvider.ActiveShadowIndex  = _shadowIndex;
            
        }
    }
}
