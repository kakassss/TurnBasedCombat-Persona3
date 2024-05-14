using Enums;
using Interfaces;

namespace Defence.Character
{
    public abstract class CharacterBaseDefence : EntityBaseDefence, ICharacterDefence
    {
        public Stat Stat => _stat;
        public DefenceTypes DefenceTypes => _defenceTypes;
        public abstract void DefenceAction();
    }
}