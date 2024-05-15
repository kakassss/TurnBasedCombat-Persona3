using System;
using Interfaces;
using UnityEngine;

[Serializable]
public class InterfaceWrapperIAttack : ISerializationCallbackReceiver
{
    [SerializeField] private ScriptableObject _attackSO;
   
    
    [NonSerialized]
    public IAttack Attack;
   
    
    public void OnAfterDeserialize()
    {
        Attack = _attackSO as IAttack;
    }

    public void OnBeforeSerialize() {}
}