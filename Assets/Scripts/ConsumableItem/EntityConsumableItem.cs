using Interfaces;
using Interfaces.Stats;
using SignalBus;

namespace ConsumableItem
{
    public abstract class EntityBaseConsumableItem : EntityBaseConsumableItemData, IConsumableItem
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
