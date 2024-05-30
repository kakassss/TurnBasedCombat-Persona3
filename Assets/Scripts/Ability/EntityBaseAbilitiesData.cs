using Enums;
using UnityEngine;

namespace Ability
{
    public abstract class EntityBaseAbilitiesData : ScriptableObject
    {
        [SerializeField] protected string _abilityName;
        [SerializeField] protected int _abilityDamageToEnemy;
        [SerializeField] protected int _manaCost;
        
        [SerializeField] protected Stat _stat;
        [SerializeField] protected AbilityTypes _abilityTypes;
    }
}