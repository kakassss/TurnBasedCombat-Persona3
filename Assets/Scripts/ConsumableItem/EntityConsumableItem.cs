using BaseEntity;
using Interfaces;
using SignalBus;

namespace ConsumableItem
{
    public class EntityConsumableItem : EntityBaseConsumableItemData, IConsumableItem
    {
        public string ItemName => _itemName;
        public int ItemValue => _itemValue;
        
        public virtual void ItemAction(IMove activeEntity)
        {
            activeEntity.MoveAction();
            EventBus<OnHealthChanged>.Fire(new OnHealthChanged());
        }
    }
}
