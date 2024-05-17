using Enums;
using Interfaces;

namespace Defence.Shadow
{
    public abstract class ShadowBaseDefence : EntityBaseDefenceData, IShadowDefence
    {
        public Stat Stat => _stat;
        public DefenceTypes DefenceTypes => _defenceTypes;
        public abstract void DefenceAction();
    }
}