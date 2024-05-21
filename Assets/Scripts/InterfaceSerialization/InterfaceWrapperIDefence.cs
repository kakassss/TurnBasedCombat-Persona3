using System;
using Interfaces;
using Interfaces.Stats;
using UnityEngine;

[Serializable]
public class InterfaceWrapperIDefence : ISerializationCallbackReceiver
{
    [SerializeField] private ScriptableObject _defenceSO;
   
    
    [NonSerialized]
    public IDefence Defence;
   
    
    public void OnAfterDeserialize()
    {
        Defence = _defenceSO as IDefence;
    }

    public void OnBeforeSerialize() {}
}