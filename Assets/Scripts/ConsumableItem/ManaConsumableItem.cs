using Interfaces;
using UnityEngine;

namespace ConsumableItem
{
    [CreateAssetMenu(fileName = "ManaConsumableItem", menuName = "ScriptableObjets/ConsumableItems/ManaConsumableItem")]
    public class ManaConsumableItem : EntityBaseConsumableItem
    {
        public override void ItemAction(IMove activeEntity)
        {
            activeEntity.entity.IncreaseMana(_itemValue);
            base.ItemAction(activeEntity);
        }
    }
}
