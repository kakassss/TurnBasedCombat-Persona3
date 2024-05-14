using Interfaces;

namespace Defence.Persona
{
    public abstract class PersonaDefence : EntityBaseDefence, IPersonaDefence
    {
        public Stat Stat => _stat;
        public DefenceTypes DefenceTypes => _defenceTypes;
        public virtual void DefenceAction()
        {
        
        }
    }
}