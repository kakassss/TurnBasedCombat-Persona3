using System.Linq;
using SelectShadow;
using SignalBus;

namespace Defence.DefenceAction
{
    public class ShadowDefenceAction : EntityDefenceAction
    {
        public override void TakeDamage(OnTakeDamage deactiveEntity)
        {
            var allShadows = _battleDataProvider.GetAllShadows();
            var activeDefence = allShadows[SelectTargetShadow.CurrentShadowIndex].entity.EntityDefences;
            var takenDamageStat = deactiveEntity.Stat;
            
            foreach (var defenceType in activeDefence.Where(defenceType => defenceType.Defence.Stat == takenDamageStat))
            {
                defenceType.Defence.DefenceAction(deactiveEntity.deactive,deactiveEntity.Stat);
            }
        }
    }
}
