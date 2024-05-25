using System.Collections.Generic;
using Enums;
using Interfaces;
using Interfaces.Stats;
using SelectShadow;
using SignalBus;

namespace Attack.Persona
{
    public abstract class PersonaBaseAttack : EntityBaseAttackData, IPersonaAttack
    {
        public Stat Stat => _stat;
        public AttackTypes AttackTypes => _attackTypes;
        public string AttackName => _attackName;
        public int AttackDamageToItself => _attackDamageToItself;
        
        public virtual void AttackAction(IMove activeEntity,List<IMove> allDeactiveEntities)
        {
            var targetShadow = allDeactiveEntities[SelectTargetShadow.CurrentShadowIndex];
            var damage = activeEntity.entity.entityBaseSo.BaseAttackValue + _attackDamageToEnemy * (int)_attackTypes;
            
            activeEntity.entity.TakeDamageUsingAttack(_attackDamageToItself);
            targetShadow.entity.TakeDamage(damage);
            
            //Debug.Log("Persona " + Stat + " Attack! " + "Total Damage: " + TotalDamage);
            
            EventBus<OnShadowTakeDamage>.Fire(new OnShadowTakeDamage
            {
                Stat =  _stat,
                persona = activeEntity,
                shadow = targetShadow,
                totalDamage = damage
            });
            activeEntity.MoveAction();
        }
    }
}