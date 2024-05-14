using Enum;

public interface IAbility
{
    Stat Stat { get; }
    void AbilityAction();
}