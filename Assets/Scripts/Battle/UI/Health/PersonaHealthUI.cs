using System.Collections.Generic;
using Interfaces;

namespace Battle.UI.Health
{
    public class PersonaHealthUI : BattleBaseHealthUI
    {
        private readonly string PersonaHealth = "PersonaHealth: ";
    
        private List<IMove> _allPersonas;
    
        protected override void SetUIData()
        {
            _allPersonas = _battleDataProvider.GetAllPersonas();
        }
    
        protected override void SetUI()
        {
            for (int i = 0; i < _allPersonas.Count; i++)
            {
                _entityHealthTexts[i].gameObject.SetActive(true);
                _entityHealthTexts[i].text = PersonaHealth + _allPersonas[i].entity.CurrentHealth.ToString();
            }
        }
    }
}
