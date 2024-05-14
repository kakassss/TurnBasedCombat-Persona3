using Defence;
using Enum;

public interface IDefence
{
    void DefenceAction();
    Stat Stat { get; }
    DefenceTypes DefenceTypes { get; }
}