using UnityEngine;

namespace ConsumableItem
{
    public class EntityBaseConsumableItemData : ScriptableObject
    {
        [SerializeField] protected string _itemName;
        [SerializeField] protected int _itemValue;
    }
}
