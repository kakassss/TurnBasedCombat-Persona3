using SignalBus;
using UnityEngine;

namespace Defence.DefenceAction
{
    public abstract class EntityDefenceAction : MonoBehaviour, ITakeDamage
    {
        protected BattleDataProvider _battleDataProvider;
        private EventBinding<OnTakeDamage> _defenceAction;

        private void Awake()
        {
            _battleDataProvider = FindObjectOfType<BattleDataProvider>();
        }

        protected virtual void OnEnable()
        {
            EnableEventBus();
        }
    
        protected virtual void OnDisable()
        {
            DisableEventBus();
        }
    
        private void EnableEventBus()
        {
            _defenceAction = new EventBinding<OnTakeDamage>(TakeDamage);
            EventBus<OnTakeDamage>.Subscribe(_defenceAction);
        }

        private void DisableEventBus()
        {
            EventBus<OnTakeDamage>.Unsubscribe(_defenceAction);
        }

        public abstract void TakeDamage(OnTakeDamage deactiveEntity);
    }
}
