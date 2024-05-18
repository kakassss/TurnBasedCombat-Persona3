using Interfaces;
using UnityEngine;

namespace ConsumableItem
{
    [CreateAssetMenu(fileName = "ManaConsumableItem", menuName = "ScriptableObjets/ConsumableItems/ManaConsumableItem")]
    public class ManaConsumableItem : EntityConsumableItem
    {
        public override void ItemAction(IMove activeEntity)
        {
            base.ItemAction(activeEntity);
            activeEntity.entity.IncreaseMana(_itemValue);
        }
    }
}
