using Enums;
using Interfaces;
using SignalBus;
using UnityEngine;

namespace Ability.Shadow
{
    public abstract class ShadowBaseAbilities : EntityBaseAbilitiesData, IShadowAbilities
    {
        public Stat Stat => _stat;
        public AbilityTypes AbilityTypes => _abilityTypes;
        public string AbilityName => _abilityName;
        public int ManaCost => _manaCost;
        public virtual void AbilityAction(IMove activeEntity, IMove deactiveEntity)
        {
            activeEntity.entity.SpendMana(_manaCost);
            deactiveEntity.entity.TakeDamage((activeEntity.entity.entityBaseSo.BaseAbilityValue + _abilityDamageToEnemy) * (int)_abilityTypes);
            
            Debug.Log("Shadow " + Stat + " Ability! " + "Total Damage: " + (activeEntity.entity.entityBaseSo.BaseAttackValue + _abilityDamageToEnemy) * (int)_abilityTypes);
            
            activeEntity.MoveAction();
            EventBus<OnHealthChanged>.Fire(new OnHealthChanged());
        }
    }
}