using Interfaces;
using TMPro;

namespace Battle.UI
{
    public class BattleActionAttackUI : BattleBaseActionUI
    {
        protected override void InstantiateActionButton(IMove actions)
        {
            var listAction = actions.entity.EntityAttacks;
        
            for (int i = 0; i < listAction.Count; i++)
            {
                var currentActionButton = _actionButtons[i];
                _actionButtons[i].gameObject.SetActive(true);
            
                var i1 = i;
                currentActionButton.onClick.AddListener(() =>
                {
                    listAction[i1].Attack.AttackAction(
                        _battleDataProvider.GetActivePersona(),
                        _battleDataProvider.GetActiveShadow());
                });
                currentActionButton.name = BUTTON_INIT_NAME + listAction[i].Attack.Stat;
                currentActionButton.GetComponentInChildren<TextMeshProUGUI>().text
                    = listAction[i].Attack.AttackName + SPACE + listAction[i].Attack.AttackDamageToItself.ToString() + SPACE + HEALTH;
            }
        }
    }
}
