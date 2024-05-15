using UnityEngine;

public class Shadow : Entity
{
    private void Awake()
    {
        Debug.Log(EntityAttacks[0].Attack.Stat);
        EntityAttacks[0].Attack.AttackAction();
        
        Debug.Log(EntityAbilities[0].Ability.Stat);
        EntityAbilities[0].Ability.AbilityAction();
        
        Debug.Log(EntityDefences[0].Defence.Stat);
        EntityDefences[0].Defence.DefenceAction();
    }

    public override void MoveAction()
    {
        
    }
}