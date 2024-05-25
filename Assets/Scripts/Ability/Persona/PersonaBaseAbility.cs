using System.Collections.Generic;
using Battle.Action;
using Enums;
using Interfaces;
using Interfaces.Stats;
using SignalBus;

namespace Ability.Persona
{
    public abstract class PersonaBaseAbility : EntityBaseAbilitiesData,IPersonaAbility
    {
        public Stat Stat => _stat;
        public AbilityTypes AbilityTypes => _abilityTypes;
        public string AbilityName => _abilityName;
        public int ManaCost => _manaCost;
        
        public virtual void AbilityAction(IMove activeEntity,List<IMove> allDeactiveEntities)
        {
            var targetShadow = allDeactiveEntities[BattleDataProvider.ActiveShadowIndex];
            var damage = (activeEntity.entity.entityBaseSo.BaseAbilityValue + _abilityDamageToEnemy) * (int)_abilityTypes;
            
            activeEntity.entity.SpendMana(_manaCost);
            targetShadow.entity.TakeDamage(damage);
            
            //Debug.Log("Persona " + Stat + " Ability! " + "Total Damage: " + (activeEntity.entity.entityBaseSo.BaseAttackValue + _abilityDamageToEnemy) * (int)_abilityTypes);
            
            EventBus<OnHealthChanged>.Fire(new OnHealthChanged());
            EventBus<OnShadowTakeDamage>.Fire(new OnShadowTakeDamage
            {
                Stat =  _stat,
                persona = activeEntity,
                shadow = targetShadow,
                totalDamage = damage,
                currentShadow = BattleDataProvider.ActiveShadowIndex
            });
            activeEntity.MoveAction();
        }
    }
}