using Interfaces;
using UnityEngine;

namespace ConsumableItem
{
    [CreateAssetMenu(fileName = "HealConsumableItem", menuName = "ScriptableObjets/ConsumableItems/HealConsumableItem")]
    public class HealConsumableItem : EntityBaseConsumableItem
    {
        public override void ItemAction(IMove activeEntity)
        {
            activeEntity.entity.Heal(_itemValue);
            base.ItemAction(activeEntity);
        }
    }
}
