using Enum;

public interface IAttack
{
    void Attack();
    Stat Stat { get; }
    AttackTypes AttackTypes { get; }
}
