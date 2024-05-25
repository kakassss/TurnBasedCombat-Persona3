using System.Collections.Generic;
using Enums;
using Interfaces;
using Interfaces.Stats;
using SignalBus;

namespace Attack.AllFoeAttacks.Shadow
{
    public class ShadowBaseAllAttack : EntityBaseAttackData, IShadowAttack
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
            
            EventBus<OnAllPersonaTakeDamage>.Fire(new OnAllPersonaTakeDamage
            {
                Stat =  _stat,
                shadow = activeEntity,
                personas = allDeactiveEntities,
                totalDamage = damage,
            });
            activeEntity.MoveAction();
        }
    }
}
