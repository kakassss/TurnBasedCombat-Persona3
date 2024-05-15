using Enums;
using Interfaces;

namespace Ability.Shadow
{
    public abstract class ShadowBaseAbilities : EntityBaseAbilities, IShadowAbilities
    {
        public Stat Stat => _stat;
        public abstract void AbilityAction();
    }
}