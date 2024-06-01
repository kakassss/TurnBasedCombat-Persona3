using System;
using Enums;
using Interfaces;
using Interfaces.Stats;
using SignalBus;

namespace Defence.Shadow
{
    public abstract class ShadowBaseDefence : EntityBaseDefenceData, IShadowDefence
    {
        public Stat Stat => _stat;
        public DefenceTypes DefenceTypes => _defenceTypes;
        
        private string _defence;
        public virtual void DefenceAction(IMove activeEntity,IMove deactiveEntity, Stat stat,int totalDamage,int currentEntityIndex)
        {
            var otherStat = stat;
            
            if (otherStat == _stat)
            {
                switch (DefenceTypes)
                {
                    case DefenceTypes.Normal:
                        _defence = "Normal";
                        break;
                    case DefenceTypes.Weakness:
                        _defence = "Weakness";
                        var damage = totalDamage / 2;
                        deactiveEntity.entity.TakeDamage(damage);
                        EventBus<OnShadowStunned>.Fire(new OnShadowStunned
                        {
                            shadow = deactiveEntity
                        });
                        deactiveEntity.entity.IsDisable = true;
                        deactiveEntity.entity.IsStunned = true;
                        break;
                    case DefenceTypes.Reflect:
                        _defence = "Reflect";
                        activeEntity.entity.TakeDamage(totalDamage / 4);
                        deactiveEntity.entity.Heal(totalDamage);
                        break;
                    case DefenceTypes.Resistance:
                        _defence = "Resistance";
                        deactiveEntity.entity.Heal(totalDamage);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            
            EventBus<OnCanAllOutAttack>.Fire(new OnCanAllOutAttack());
            EventBus<OnHealthChanged>.Fire(new OnHealthChanged());
            EventBus<OnShadowDefenceActionUI>.Fire(new OnShadowDefenceActionUI
            {
                defenceType = _defence,
                activeShadowIndex = currentEntityIndex
            });
            
        }
    }
}