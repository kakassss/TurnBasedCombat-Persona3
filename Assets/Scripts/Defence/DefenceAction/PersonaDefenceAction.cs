using System.Linq;
using SignalBus;

namespace Defence.DefenceAction
{
    public class PersonaDefenceAction : EntityDefenceAction
    {
        private EventBinding<OnPersonaTakeDamage> _personaDefenceAction;
        
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
            _personaDefenceAction = new EventBinding<OnPersonaTakeDamage>(TakeDamage);
            EventBus<OnPersonaTakeDamage>.Subscribe(_personaDefenceAction);
        }

        private void DisableEventBus()
        {
            EventBus<OnPersonaTakeDamage>.Unsubscribe(_personaDefenceAction);
        }
        
        private void TakeDamage(OnPersonaTakeDamage persona)
        {
            var allPersonas = _battleDataProvider.GetAllPersonas();
            var activeDefence = allPersonas[persona.currentPersona].entity.EntityDefences;
            var takenDamageStat = persona.Stat;
            
            foreach (var defenceType in activeDefence.Where(defenceType => defenceType.Defence.Stat == takenDamageStat))
            {
                defenceType.Defence.DefenceAction(persona.shadow,persona.persona,persona.Stat,persona.totalDamage,persona.currentPersona);
            }
        }
    }
}
