using System.Linq;
using SignalBus;

namespace Defence.DefenceAction
{
    public class PersonaDefenceAction : EntityDefenceAction
    {
        public override void TakeDamage(OnTakeDamage deactiveEntity)
        {
            var activeDefence = _battleDataProvider.GetActivePersona().entity.EntityDefences; 
            var takenDamageStat = deactiveEntity.Stat;
            
            foreach (var defenceType in activeDefence.Where(defenceType => defenceType.Defence.Stat == takenDamageStat))
            {
                defenceType.Defence.DefenceAction(deactiveEntity.deactive,deactiveEntity.Stat);
            }
        }
    }
}
