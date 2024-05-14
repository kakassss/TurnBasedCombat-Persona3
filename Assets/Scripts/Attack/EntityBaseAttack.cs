using Enums;
using UnityEngine;

namespace Attack
{
    public abstract class EntityBaseAttack : ScriptableObject
    {
        public string AttackName;
    
        [SerializeField] protected Stat _stat;
        [SerializeField] protected AttackTypes _attackTypes;
    }
}