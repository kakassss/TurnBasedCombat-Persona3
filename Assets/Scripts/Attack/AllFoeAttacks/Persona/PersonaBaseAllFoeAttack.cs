using System.Collections.Generic;
using Battle.Action;
using Enums;
using Interfaces;
using Interfaces.Stats;
using SignalBus;

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
            var damage = (activeEntity.entity.entityBaseSo.BaseAttackValue + _attackDamageToEnemy) * (int)_attackTypes;
            activeEntity.entity.TakeDamageUsingAttack(_attackDamageToItself);
            
            foreach (var targetShadow in allDeactiveEntities)
            {
                targetShadow.entity.TakeDamage(damage);
            }
            
            EventBus<OnAllShadowTakeDamage>.Fire(new OnAllShadowTakeDamage
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
