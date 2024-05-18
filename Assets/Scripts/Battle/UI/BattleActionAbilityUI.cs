using Interfaces;
using TMPro;

public class BattleActionAbilityUI : BattleBaseActionUI
{
    protected override void InstantiateActionButton(IMove actions)
    {
        var listAction = actions.entity.EntityAbilities;
        
        for (int i = 0; i < listAction.Count; i++)
        {
            var currentActionButton = _actionButtons[i];
            _actionButtons[i].gameObject.SetActive(true);
            
            var i1 = i;
            currentActionButton.onClick.AddListener(() =>
            {
                listAction[i1].Ability.AbilityAction(
                    _battleDataProvider.GetActiveEntity(),
                    _battleDataProvider.GetDeactiveEntity());
            });
            currentActionButton.name = BUTTON_INIT_NAME + listAction[i].Ability.Stat;
            currentActionButton.GetComponentInChildren<TextMeshProUGUI>().text
                = listAction[i].Ability.AbilityName + SPACE + listAction[i].Ability.ManaCost.ToString() + SPACE + MANA;
        }
    }
    
}