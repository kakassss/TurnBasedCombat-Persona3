namespace Defence.Character
{
    public abstract class CharacterDefence : EntityBaseDefence, ICharacterDefence
    {
        public Stat Stat => _stat;
        public DefenceTypes DefenceTypes => _defenceTypes;

        public virtual void DefenceAction()
        {
        }
    }
}