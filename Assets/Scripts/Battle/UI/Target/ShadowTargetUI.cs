using SignalBus;

namespace Battle.UI.Target
{
    public class ShadowTargetUI : EntityBaseTargetUI
    {
        private EventBinding<OnShadowTargetChanged> _targetUIAction;
        
        protected override void EnableEventBus()
        {
            base.EnableEventBus();
            _targetUIAction = new EventBinding<OnShadowTargetChanged>(SetTargetUI);
            EventBus<OnShadowTargetChanged>.Subscribe(_targetUIAction);
        }
    
        protected override void DisableEventBus()
        {
            base.DisableEventBus();
            EventBus<OnShadowTargetChanged>.Unsubscribe(_targetUIAction);
        }

        protected override void InitTargetImageUI()
        {
            foreach (var targetImage in _targetImages)
            {
                targetImage.gameObject.SetActive(false);
            }
            _targetImages[0].gameObject.SetActive(true);
        }
    
        private void SetTargetUI(OnShadowTargetChanged shadow)
        {
            foreach (var targetImage in _targetImages)
            {
                targetImage.gameObject.SetActive(false);
            }
        
            _targetImages[shadow.ActiveShadowIndex].gameObject.SetActive(true);
        }
        
    }
}
