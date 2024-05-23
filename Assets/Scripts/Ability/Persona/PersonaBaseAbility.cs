using System.Collections.Generic;
using Enums;
using Interfaces;
using Interfaces.Stats;
using SignalBus;
using UnityEngine;

namespace Ability.Persona
{
    public abstract class PersonaBaseAbility : EntityBaseAbilitiesData,IPersonaAbility
    {
        public Stat Stat => _stat;
        public AbilityTypes AbilityTypes => _abilityTypes;
        public string AbilityName => _abilityName;
        public int ManaCost => _manaCost;
        
        private int _randomShadow;
        public virtual void AbilityAction(IMove activeEntity,List<IMove> allDeactiveEntities)
        {
            _randomShadow = Helper.GetRandomNumber(0, allDeactiveEntities.Count);
            var targetShadow = allDeactiveEntities[_randomShadow];
            
            activeEntity.entity.SpendMana(_manaCost);
            targetShadow.entity.TakeDamage((activeEntity.entity.entityBaseSo.BaseAbilityValue + _abilityDamageToEnemy) * (int)_abilityTypes);
            
            Debug.Log("Persona " + Stat + " Ability! " + "Total Damage: " + (activeEntity.entity.entityBaseSo.BaseAttackValue + _abilityDamageToEnemy) * (int)_abilityTypes);
            
            activeEntity.MoveAction();
            EventBus<OnHealthChanged>.Fire(new OnHealthChanged());
            EventBus<OnShadowTakeDamage>.Fire(new OnShadowTakeDamage
            {
                Stat =  _stat,
                persona = activeEntity
            });
        }
    }
}