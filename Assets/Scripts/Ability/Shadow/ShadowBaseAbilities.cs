using System.Collections.Generic;
using Enums;
using Interfaces;
using Interfaces.Stats;
using SignalBus;

namespace Ability.Shadow
{
    public abstract class ShadowBaseAbilities : EntityBaseAbilitiesData, IShadowAbilities
    {
        public Stat Stat => _stat;
        public AbilityTypes AbilityTypes => _abilityTypes;
        public string AbilityName => _abilityName;
        public int ManaCost => _manaCost;
        
        private int _randomPersona;
        public virtual void AbilityAction(IMove activeEntity,List<IMove> allDeactiveEntities)
        {
            _randomPersona = Helper.GetRandomNumber(0, allDeactiveEntities.Count);
            var targetPersona = allDeactiveEntities[_randomPersona];
            var damage = (activeEntity.entity.entityBaseSo.BaseAbilityValue + _abilityDamageToEnemy) * (int)_abilityTypes;
            
            //activeEntity.entity.SpendMana(_manaCost);
            targetPersona.entity.TakeDamage(damage);
            
            //Debug.Log("Shadow " + Stat + " Ability! " + "Total Damage: " + (activeEntity.entity.entityBaseSo.BaseAttackValue + _abilityDamageToEnemy) * (int)_abilityTypes);
            
            
            EventBus<OnHealthChanged>.Fire(new OnHealthChanged());
            EventBus<OnPersonaTakeDamage>.Fire(new OnPersonaTakeDamage
            {
                Stat =  _stat,
                persona = targetPersona,
                shadow = activeEntity,
                totalDamage = damage,
                currentPersona = _randomPersona
            });
            activeEntity.MoveAction();
        }
    }
}