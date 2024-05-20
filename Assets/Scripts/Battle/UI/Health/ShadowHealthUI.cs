using System.Collections.Generic;
using Interfaces;

namespace Battle.UI.Health
{
    public class ShadowHealthUI : BattleBaseHealthUI
    {
        private readonly string ShadowHealth = "ShadowHealth: ";
    
        private List<IMove> _allShadows;
    
        protected override void SetUIData()
        {
            _allShadows = _battleDataProvider.GetAllShadows();
        }
    
        protected override void SetUI()
        {
            for (int i = 0; i < _allShadows.Count; i++)
            {
                _entityHealthTexts[i].gameObject.SetActive(true);
                _entityHealthTexts[i].text = ShadowHealth + _allShadows[i].entity.CurrentHealth.ToString();
            }
        }
    }
}
