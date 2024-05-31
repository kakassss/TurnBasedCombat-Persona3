using System.Collections.Generic;
using Interfaces;

namespace BaseEntity
{
    public class Persona : Entity
    {
        public List<InterfaceWrapperIConsumableItem> PersonaConsumableItems;

        public override void MoveAction()
        {
            base.MoveAction();
            
            
        }
    }
}