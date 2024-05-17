using Interfaces;
using TMPro;

public class BattleActionAttackUI : BattleBaseActionUI
{
    protected override void InstantiateActionButton(IMove actions)
    {
        var listAction = actions.entity.EntityAttacks;
        
        foreach (var action in listAction)
        {
            var currentActionButton = Instantiate(_actionButton, _actionGroup.transform);
                
            currentActionButton.onClick.AddListener(() =>
            {
                action.Attack.AttackAction(
                    _battleDataProvider.GetActiveEntity(),
                    _battleDataProvider.GetDeactiveEntity());
            });
            currentActionButton.name = BUTTON_INIT_NAME + action.Attack.Stat;
            currentActionButton.GetComponentInChildren<TextMeshProUGUI>().text
                = action.Attack.AttackName + SPACE + action.Attack.AttackDamageToItself.ToString() + SPACE + HEALTH;
        }
        
        
    }
}
