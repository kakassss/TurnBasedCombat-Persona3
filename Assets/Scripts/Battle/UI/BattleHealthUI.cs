using SignalBus;
using TMPro;
using UnityEngine;

namespace Battle.UI
{
    public class BattleHealthUI : MonoBehaviour
    {
        private readonly string PersonaHealth = "PersonaHealth: ";
        private readonly string ShadowHealth = "ShadowHealth: ";

        [SerializeField] private BattleDataProvider _battleDataProvider;
    
        [SerializeField] private TextMeshProUGUI _personaHealthText;
        [SerializeField] private TextMeshProUGUI _shadowHealthText;
    
        private EventBinding<OnHealthChanged> _takeDamage;

        private int _personaHealth;
        private int _shadowHealth;
    
        private void Start()
        {
            SetUI();
            EnableEventBus();
        }

        private void OnDisable()
        {
            DisableEventBus();
        }

        private void EnableEventBus()
        {
            _takeDamage = new EventBinding<OnHealthChanged>(SetUI);
            EventBus<OnHealthChanged>.Subscribe(_takeDamage);
        }

        private void DisableEventBus()
        {
            EventBus<OnHealthChanged>.Unsubscribe(_takeDamage);
        }

        private void SetUI()
        {
            Debug.Log("1111");
            _personaHealth = _battleDataProvider.GetActivePersona().entity.CurrentHealth;
            _shadowHealth = _battleDataProvider.GetActiveShadow().entity.CurrentHealth;

            _personaHealthText.text = PersonaHealth + _personaHealth.ToString();
            _shadowHealthText.text = ShadowHealth + _shadowHealth.ToString();
        }
    
    }
}
