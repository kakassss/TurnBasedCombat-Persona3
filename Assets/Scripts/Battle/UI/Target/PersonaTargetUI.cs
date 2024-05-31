using Battle.Action;

namespace Battle.UI.Target
{
    public class PersonaTargetUI : EntityBaseTargetUI
    {
        protected override void InitTargetImageUI()
        {
            foreach (var targetImage in _targetImages)
            {
                targetImage.gameObject.SetActive(false);
            }
            _targetImages[BattleDataProvider.ActivePersonaIndex].gameObject.SetActive(true);
        }
    
        private void SetTargetUI()
        {
            foreach (var targetImage in _targetImages)
            {
                targetImage.gameObject.SetActive(false);
            }
            _targetImages[BattleDataProvider.ActivePersonaIndex].gameObject.SetActive(true);
        }

        protected override void EnableImageUI()
        {
            base.EnableImageUI();
            SetTargetUI();
        }
    }
}
