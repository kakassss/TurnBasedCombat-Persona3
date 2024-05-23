using System.Linq;
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
        
        private void TakeDamage(OnShadowTakeDamage persona)
        {
            var allShadows = _battleDataProvider.GetAllShadows();
            var activeDefence = allShadows[SelectTargetShadow.CurrentShadowIndex].entity.EntityDefences;
            var takenDamageStat = persona.Stat;

            foreach (var defenceType in activeDefence)
            {
                if (defenceType.Defence.Stat == takenDamageStat)
                {
                    Debug.Log("onur burda xdddd " + persona.totalDamage);
                    defenceType.Defence.DefenceAction(persona.persona,persona.shadow,persona.Stat,persona.totalDamage);
                }
            }
            
        }
    }
}
