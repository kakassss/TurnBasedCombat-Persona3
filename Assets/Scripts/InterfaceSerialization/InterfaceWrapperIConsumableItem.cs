using System;
using Interfaces;
using UnityEngine;

[Serializable]
public class InterfaceWrapperIConsumableItem : ISerializationCallbackReceiver
{
    [SerializeField] private ScriptableObject _itemSO;
   
    
    [NonSerialized]
    public IConsumableItem Item;
    
    public void OnAfterDeserialize()
    {
        Item = _itemSO as IConsumableItem;
    }

    public void OnBeforeSerialize() {}
}
