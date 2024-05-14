using Enum;

namespace Attack
{
    public abstract class CharacterBaseAttack : EntityBaseAttack, IPersonaAttack
    {
        public Stat Stat => _stat;
        public AttackTypes AttackTypes => _attackTypes;

        public abstract void Attack();
    }
}