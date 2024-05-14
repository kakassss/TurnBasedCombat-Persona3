using Enum;

namespace Ability.Persona
{
    public abstract class PersonaBaseAbility : EntityBaseAbilities,IPersonaAbility
    {
        public Stat Stat => _stat;
        public abstract void AbilityAction();
    }
}