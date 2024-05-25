using System.Collections.Generic;
using SignalBus;
using UnityEngine;
using UnityEngine.UI;

namespace Battle.UI.Target
{
    public abstract class EntityBaseTargetUI : MonoBehaviour
    {
        [SerializeField] protected List<Image> _targetImages;
        private EventBinding<OnPersonaTurn> _personaTurn;
        private EventBinding<OnShadowTurn> _shadowTurn;

        private void OnEnable()
        {
            EnableEventBus();
            InitTargetImageUI();
        }
    
        private void OnDisable()
        {
            DisableEventBus();
        }
    
        protected virtual void EnableEventBus()
        {
            _personaTurn = new EventBinding<OnPersonaTurn>(EnableImageUI);
            EventBus<OnPersonaTurn>.Subscribe(_personaTurn);
        
            _shadowTurn = new EventBinding<OnShadowTurn>(DisableImageUI);
            EventBus<OnShadowTurn>.Subscribe(_shadowTurn);
        }
    
        protected virtual void DisableEventBus()
        {
            EventBus<OnPersonaTurn>.Unsubscribe(_personaTurn);
            EventBus<OnShadowTurn>.Unsubscribe(_shadowTurn);
        }
    
        protected virtual void EnableImageUI()
        {
            InitTargetImageUI();
        }
    
        private void DisableImageUI()
        {
            foreach (var targetImage in _targetImages)
            {
                targetImage.gameObject.SetActive(false);
            }
        }
    
        protected abstract void InitTargetImageUI();
    }
}
