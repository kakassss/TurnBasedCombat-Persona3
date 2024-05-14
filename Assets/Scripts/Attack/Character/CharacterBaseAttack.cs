using Enums;
using Interfaces;

namespace Attack.Character
{
    public abstract class CharacterBaseAttack : EntityBaseAttack, IPersonaAttack
    {
        public Stat Stat => _stat;
        public AttackTypes AttackTypes => _attackTypes;

        public abstract void Attack();
    }
}