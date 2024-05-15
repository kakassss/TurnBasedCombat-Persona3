using Enums;

namespace Interfaces
{
    public interface IDefence
    {
        void DefenceAction();
        Stat Stat { get; }
        DefenceTypes DefenceTypes { get; }
    }
}