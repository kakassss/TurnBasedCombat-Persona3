using System.Collections.Generic;
using Enums;
using Interfaces;
using Interfaces.Stats;
using SignalBus;
using UnityEngine;

namespace Attack.AllFoeAttacks
{
    public class PersonaBaseAllFoeAttack : EntityBaseAttackData, IPersonaAttack
    {
        public Stat Stat => _stat;
        public AttackTypes AttackTypes => _attackTypes;
        public string AttackName => _attackName;
        public int AttackDamageToItself => _attackDamageToItself;
    
        public void AttackAction(IMove activeEntity, List<IMove> allDeactiveEntities)
        {
            activeEntity.entity.TakeDamageUsingAttack(_attackDamageToItself);
            foreach (var deactiveEntity in allDeactiveEntities)
            {
                deactiveEntity.entity.TakeDamage((activeEntity.entity.entityBaseSo.BaseAttackValue + _attackDamageToEnemy) * (int)_attackTypes);
            }
            
            Debug.Log("Persona " + Stat + " Attack! " + "Total Damage: " + (activeEntity.entity.entityBaseSo.BaseAttackValue + _attackDamageToEnemy) * (int)_attackTypes);
            
            activeEntity.MoveAction();
            EventBus<OnHealthChanged>.Fire(new OnHealthChanged());
            EventBus<OnShadowTakeDamage>.Fire(new OnShadowTakeDamage
            {
                Stat =  _stat,
                deactive = activeEntity
            });
        }
    }
}
