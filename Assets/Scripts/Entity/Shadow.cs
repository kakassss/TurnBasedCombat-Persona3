using Interfaces;
using UnityEngine;

namespace BaseEntity
{
    public class Shadow : Entity
    {
        public override void MoveAction(IMove deactiveEntity,IMove activeEntity)
        {
            Debug.Log("Shadow Turn");
            Debug.Log("Shadow choose his moves");
            Debug.Log("1 Attack || 2 Ability || 3 Defence");

            int random = Helper.GetRandomNumber(0, 3);
            
            
            if (random == 0)
            {
                Debug.Log("Shadow is Attacking");    
                EntityAttacks[Helper.GetRandomNumber(0, EntityAttacks.Count)].Attack.AttackAction(deactiveEntity,activeEntity);
            }
            else if(random == 1)
            {
                Debug.Log("Shadow is using his ability");
                EntityAbilities[Helper.GetRandomNumber(0, EntityAbilities.Count)].Ability.AbilityAction();
            }
            else if(random == 2)
            {
                Debug.Log("Shadow is defending itself");
                EntityDefences[Helper.GetRandomNumber(0,EntityDefences.Count)].Defence.DefenceAction();
            }
        }
    }
}