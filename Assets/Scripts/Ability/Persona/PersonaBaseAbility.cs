using Enums;
using Interfaces;

namespace Ability.Persona
{
    public abstract class PersonaBaseAbility : EntityBaseAbilitiesData,IPersonaAbility
    {
        public Stat Stat => _stat;
        public AttackTypes AttackTypes => _attackTypes;
        public abstract void AbilityAction(IMove activeEntity,IMove deactiveEntity);
    }
}