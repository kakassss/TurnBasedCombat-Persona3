using EntityData;
using Enums;
using UnityEngine;
using UnityEngine.Serialization;

namespace Attack
{
    public abstract class EntityBaseAttack : ScriptableObject
    {
        public string AttackName;
        [SerializeField] protected int _attackDamageToEnemy;
        [SerializeField] protected int _attackDamageToItself;
        
        [SerializeField] protected Stat _stat;
        [SerializeField] protected AttackTypes _attackTypes;
    }
}