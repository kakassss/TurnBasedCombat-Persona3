using System;
using Interfaces;
using UnityEngine;

[Serializable]
public class InterfaceWrapperIAbility : ISerializationCallbackReceiver
{
    [SerializeField] private ScriptableObject _abilitySO;
   
    
    [NonSerialized]
    public IAbility Ability;
   
    
    public void OnAfterDeserialize()
    {
        Ability = _abilitySO as IAbility;
    }

    public void OnBeforeSerialize() {}
}