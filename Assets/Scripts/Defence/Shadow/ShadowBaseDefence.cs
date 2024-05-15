using Enums;
using Interfaces;

namespace Defence.Shadow
{
    public abstract class ShadowBaseDefence : EntityBaseDefence, IShadowDefence
    {
        public Stat Stat => _stat;
        public DefenceTypes DefenceTypes => _defenceTypes;
        public abstract void DefenceAction();
    }
}