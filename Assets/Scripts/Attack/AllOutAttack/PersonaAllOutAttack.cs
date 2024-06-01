using System.Collections.Generic;
using Attack.AllFoeAttacks.Persona;
using Interfaces;
using SignalBus;
using UnityEngine;

namespace Attack.AllOutAttack
{
    [CreateAssetMenu(fileName = "PersonaAllOutAttack", menuName = "ScriptableObjets/PersonaAllOutAttack/PersonaAllOutAttack")]
    public class PersonaAllOutAttack : PersonaBaseAllFoeAttack
    {
        public override void AttackAction(IMove activeEntity, List<IMove> allDeactiveEntities)
        {
            var damage = (activeEntity.entity.entityBaseSo.BaseAttackValue + _attackDamageToEnemy) * (int)_attackTypes;
            activeEntity.entity.TakeDamageUsingAttack(_attackDamageToItself);
        
            foreach (var targetShadow in allDeactiveEntities)
            {
                targetShadow.entity.TakeDamage(damage);
            }
        
            EventBus<OnAllOutShadowTakeDamage>.Fire(new OnAllOutShadowTakeDamage
            {
                Stat =  _stat,
                persona = activeEntity,
                shadows = allDeactiveEntities,
                totalDamage = damage,
            });
            
            activeEntity.MoveAction();
        }
    }
}
