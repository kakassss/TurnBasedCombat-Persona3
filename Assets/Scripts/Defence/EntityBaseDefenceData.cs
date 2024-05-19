using Enums;
using UnityEngine;

namespace Defence
{
    public abstract class EntityBaseDefenceData : ScriptableObject
    {
        [SerializeField] protected string _defenceName;
    
        [SerializeField] protected Stat _stat;
        [SerializeField] protected DefenceTypes _defenceTypes;
    }
}