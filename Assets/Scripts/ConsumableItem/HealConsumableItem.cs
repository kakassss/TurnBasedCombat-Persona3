using Interfaces;
using UnityEngine;

namespace ConsumableItem
{
    [CreateAssetMenu(fileName = "HealConsumableItem", menuName = "ScriptableObjets/ConsumableItems/HealConsumableItem")]
    public class HealConsumableItem : EntityConsumableItem
    {
        public override void ItemAction(IMove activeEntity)
        {
            base.ItemAction(activeEntity);
            activeEntity.entity.Heal(_itemValue);
        }
    }
}
