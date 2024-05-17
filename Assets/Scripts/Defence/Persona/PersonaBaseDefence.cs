using Enums;
using Interfaces;

namespace Defence.Persona
{
    public abstract class PersonaBaseDefence : EntityBaseDefenceData, IPersonaDefence
    {
        public Stat Stat => _stat;
        public DefenceTypes DefenceTypes => _defenceTypes;
        public abstract void DefenceAction();
    }
}