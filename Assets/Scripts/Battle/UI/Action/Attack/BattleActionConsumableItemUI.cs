using BaseEntity;
using Interfaces;
using TMPro;
using UnityEngine;

namespace Battle.UI.Action.Attack
{
    public class BattleActionConsumableItemUI : BattleBaseActionUI
    {
        [SerializeField] private GameObject _consumableItemUI;
        [SerializeField] private GameObject _consumableItemButton;
        
        protected override void InstantiateActionButton(IMove actions)
        {
            Persona personaItem = null;
            var listAction = actions.entity;

            if (listAction is Persona action)
                personaItem = action;

            var personaItemList = personaItem.PersonaConsumableItems;

            for (int i = 0; i < personaItemList.Count; i++)
            {
                var currentActionButton = _actionButtons[i];
                _actionButtons[i].gameObject.SetActive(true);
            
                var i1 = i;
                currentActionButton.onClick.AddListener(() =>
                {
                    personaItemList[i1].Item.ItemAction(_battleDataProvider.GetActivePersona());
                });
                currentActionButton.name = BUTTON_INIT_NAME + personaItemList[i].Item.ItemName;
                currentActionButton.GetComponentInChildren<TextMeshProUGUI>().text
                    = personaItemList[i].Item.ItemName + SPACE + personaItemList[i].Item.ItemValue.ToString() + SPACE;
            }

        }
    }
}
