using System.Linq;
using Battle.Action;
using SelectShadow;
using SignalBus;
using UnityEngine;

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
        
        private void TakeDamage(OnShadowTakeDamage shadow)
        {
            var allShadows = _battleDataProvider.GetAllShadows();
            var activeDefence = allShadows[BattleDataProvider.ActiveShadowIndex].entity.EntityDefences;
            var takenDamageStat = shadow.Stat;
            
            foreach (var defenceType in activeDefence.Where(defenceType => defenceType.Defence.Stat == takenDamageStat))
            {
                defenceType.Defence.DefenceAction(shadow.persona,shadow.shadow,shadow.Stat,shadow.totalDamage);
            }
        }
    }
}
