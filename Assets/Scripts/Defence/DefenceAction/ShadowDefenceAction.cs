using System.Linq;
using SignalBus;

namespace Defence.DefenceAction
{
    public class ShadowDefenceAction : EntityDefenceAction
    {
        private EventBinding<OnShadowTakeDamage> _shadowDefenceAction;
        private EventBinding<OnAllShadowTakeDamage> _shadowAllDefenceAction;
        
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
            
            _shadowAllDefenceAction = new EventBinding<OnAllShadowTakeDamage>(TakeAllShadowDamage);
            EventBus<OnAllShadowTakeDamage>.Subscribe(_shadowAllDefenceAction);
        }

        private void DisableEventBus()
        {
            EventBus<OnShadowTakeDamage>.Unsubscribe(_shadowDefenceAction);
            EventBus<OnAllShadowTakeDamage>.Unsubscribe(_shadowAllDefenceAction);
        }
        
        private void TakeDamage(OnShadowTakeDamage shadow)
        {
            var allShadows = _battleDataProvider.GetAllShadows();
            var activeDefence = allShadows[shadow.currentShadow].entity.EntityDefences;
            var takenDamageStat = shadow.Stat;
            
            foreach (var defenceType in activeDefence.Where(defenceType => defenceType.Defence.Stat == takenDamageStat))
            {
                defenceType.Defence.DefenceAction(shadow.persona,shadow.shadow,
                    shadow.Stat,shadow.totalDamage,shadow.currentShadow);
            }
        }

        private void TakeAllShadowDamage(OnAllShadowTakeDamage allShadows)
        {
            var shadows = allShadows.shadows;

            foreach (var shadow in shadows)
            {
                foreach (var defence in shadow.entity.EntityDefences.Where(defence => defence.Defence.Stat == allShadows.Stat))
                {
                    defence.Defence.DefenceAction(allShadows.persona,shadow,
                        allShadows.Stat,allShadows.totalDamage,allShadows.currentShadow);
                    allShadows.currentShadow++;
                }
            }
        }
    }
}
