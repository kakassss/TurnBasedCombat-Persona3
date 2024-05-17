using Enums;
using Interfaces;

namespace Ability.Shadow
{
    public abstract class ShadowBaseAbilities : EntityBaseAbilitiesData, IShadowAbilities
    {
        public Stat Stat => _stat;
        public AttackTypes AttackTypes => _attackTypes;
        public abstract void AbilityAction();
    }
}