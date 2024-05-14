using UnityEngine;

namespace Defence
{
    public abstract class EntityBaseDefence : ScriptableObject
    {
        public string DefenceName;
    
        [SerializeField] protected Stat _stat;
        [SerializeField] protected DefenceTypes _defenceTypes;
    }

    public enum DefenceTypes
    {
        Weakness,
        Normal,
        Resistance,
        Reflect
    }
}