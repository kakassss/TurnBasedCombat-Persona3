using Enums;
using UnityEngine;

namespace Attack
{
    public abstract class EntityBaseAttackData : ScriptableObject
    {
        [SerializeField] protected string _attackName;
        [SerializeField] protected int _attackDamageToEnemy;
        [SerializeField] protected int _attackDamageToItself;
        
        [SerializeField] protected Stat _stat;
        [SerializeField] protected AttackTypes _attackTypes;
    }
}