using System.Linq;
using SignalBus;

namespace Defence.DefenceAction
{
    public class ShadowDefenceAction : EntityDefenceAction
    {
        public override void TakeDamage(OnTakeDamage deactiveEntity)
        {
            var activeDefence = _battleDataProvider.GetActiveShadow().entity.EntityDefences;
            var takenDamageStat = deactiveEntity.Stat;
            
            foreach (var defenceType in activeDefence.Where(defenceType => defenceType.Defence.Stat == takenDamageStat))
            {
                defenceType.Defence.DefenceAction(deactiveEntity.deactive,deactiveEntity.Stat);
            }
        }
    }
}
