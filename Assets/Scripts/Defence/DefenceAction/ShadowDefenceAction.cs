using System.Linq;
using SelectShadow;
using SignalBus;

namespace Defence.DefenceAction
{
    public class ShadowDefenceAction : EntityDefenceAction
    {
        private EventBinding<OnShadowTakeDamage> _shadowDefenceAction;
        
        private void OnEnable()
        {
            EnableEventBus();
        }
    
        private void OnDisable()
        {
            DisableEventBus();
        }
    
        private void EnableEventBus()
        {
            _shadowDefenceAction = new EventBinding<OnShadowTakeDamage>(TakeDamage);
            EventBus<OnShadowTakeDamage>.Subscribe(_shadowDefenceAction);
        }

        private void DisableEventBus()
        {
            EventBus<OnShadowTakeDamage>.Unsubscribe(_shadowDefenceAction);
        }
        
        private void TakeDamage(OnShadowTakeDamage deactiveEntity)
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
