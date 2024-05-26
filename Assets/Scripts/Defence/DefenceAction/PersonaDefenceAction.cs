using System.Linq;
using SignalBus;

namespace Defence.DefenceAction
{
    public class PersonaDefenceAction : EntityDefenceAction
    {
        private EventBinding<OnPersonaTakeDamage> _personaDefenceAction;
        private EventBinding<OnAllPersonaTakeDamage> _personaAllDefenceAction;
        
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
            
            _personaAllDefenceAction = new EventBinding<OnAllPersonaTakeDamage>(TakeAllShadowDamage);
            EventBus<OnAllPersonaTakeDamage>.Subscribe(_personaAllDefenceAction);
        }

        private void DisableEventBus()
        {
            EventBus<OnPersonaTakeDamage>.Unsubscribe(_personaDefenceAction);
            EventBus<OnAllPersonaTakeDamage>.Unsubscribe(_personaAllDefenceAction);
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
        
        private void TakeAllShadowDamage(OnAllPersonaTakeDamage allPersonas)
        {
            var personas = allPersonas.personas;
            
            foreach (var persona in personas)
            {
                foreach (var defence in persona.entity.EntityDefences.Where(defence => defence.Defence.Stat == allPersonas.Stat))
                {
                    defence.Defence.DefenceAction(allPersonas.shadow,persona,
                        allPersonas.Stat,allPersonas.totalDamage,allPersonas.currentPersona);
                    allPersonas.currentPersona++;
                }
            }
        }
    }
}
