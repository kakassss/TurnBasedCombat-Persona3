using SignalBus;
using UnityEngine;

namespace Battle.UI.Action.ShadowDead
{
    public class ShadowDeadAction : MonoBehaviour
    {
        private EventBinding<OnIsShadowDead> _onShadowDead;
        
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
            _onShadowDead = new EventBinding<OnIsShadowDead>(OnShadowDead);
            EventBus<OnIsShadowDead>.Subscribe(_onShadowDead);
        }
        
        private void DisableEventBus()
        {
            EventBus<OnIsShadowDead>.Unsubscribe(_onShadowDead);
        }
        
        private void OnShadowDead(OnIsShadowDead dead)
        {
            if (dead.shadow.entity.GetHealth() > 0) return;
            
            dead.shadow.entity.IsDead = true;
            EventBus<OnShadowDeadUI>.Fire(new OnShadowDeadUI
            {
                shadow = dead.shadow,
                activeShadowIndex = dead.activeShadowIndex
            });
        }
    }
}
