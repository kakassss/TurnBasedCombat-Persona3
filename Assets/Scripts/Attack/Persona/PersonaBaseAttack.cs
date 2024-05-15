using Enums;
using Interfaces;

namespace Attack.Persona
{
    public abstract class PersonaBaseAttack : EntityBaseAttack, IPersonaAttack
    {
        public Stat Stat => _stat;
        public AttackTypes AttackTypes => _attackTypes;
        public abstract void AttackAction();
    }
}