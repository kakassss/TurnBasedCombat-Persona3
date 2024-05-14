using Enums;
using Interfaces;

namespace Ability.Character
{
    public abstract class CharacterBaseAbilities : EntityBaseAbilities, ICharacterAbilities
    {
        public Stat Stat => _stat;
        public abstract void AbilityAction();
    }
}