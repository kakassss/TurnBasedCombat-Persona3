using System;
using Enums;
using Interfaces;
using Interfaces.Stats;
using SignalBus;

namespace Defence.Persona
{
    public abstract class PersonaBaseDefence : EntityBaseDefenceData, IPersonaDefence
    {
        public Stat Stat => _stat;
        public DefenceTypes DefenceTypes => _defenceTypes;
        private string _defence;
        public virtual void DefenceAction(IMove activeEntity,IMove deactiveEntity, Stat stat, int totalDamage)
        {
            //kendi kendi verdiği hasardan buraya girebiliyor
            switch (DefenceTypes)
            {
                case DefenceTypes.Normal:
                    break;
                case DefenceTypes.Weakness:
                    break;
                case DefenceTypes.Reflect:
                    break;
                case DefenceTypes.Resistance:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            EventBus<OnDefenceActionUI>.Fire(new OnDefenceActionUI
            {
                defenceType = _defence
            });
            
        }
    }
}