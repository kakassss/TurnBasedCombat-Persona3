using Interfaces;
using UnityEngine;

namespace BaseEntity
{
    public class Persona : Entity
    {
        public override void MoveAction(IMove deactiveEntity,IMove activeEntity)
        {
            Debug.Log("Persona Turn");
            Debug.Log("Select Persona Move");
            Debug.Log("1 Attack || 2 Ability || 3 Defence");
            
            int random = Helper.GetRandomNumber(0, 3);
            
            
            if (random == 0)
            {
                Debug.Log("Persona is Attacking");    
                EntityAttacks[Helper.GetRandomNumber(0, EntityAttacks.Count)].Attack.AttackAction(deactiveEntity,activeEntity);
            }
            else if(random == 1)
            {
                Debug.Log("Persona is using his ability");
                EntityAbilities[Helper.GetRandomNumber(0, EntityAbilities.Count)].Ability.AbilityAction();
            }
            else if(random == 2)
            {
                Debug.Log("Persona is defending itself");
                EntityDefences[Helper.GetRandomNumber(0,EntityDefences.Count)].Defence.DefenceAction();
            }
        }
    }
}