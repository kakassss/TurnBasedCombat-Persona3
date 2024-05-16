using TMPro;
using UnityEngine;

public class BattleUI : MonoBehaviour
{
    private readonly string PersonaHealth = "PersonaHealth: ";
    private readonly string ShadowHealth = "ShadowHealth: ";

    [SerializeField] private BattleDataProvider _battleDataProvider;
    
    [SerializeField] private TextMeshProUGUI _personaHealth;
    [SerializeField] private TextMeshProUGUI _shadowHealth;
    
    private EventBinding<OnHealthChanged> _takeDamage;
    
    private void Start()
    {
        InitUI();
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

    private void InitUI()
    {
        var personaHealth = _battleDataProvider.GetPersona().entity.CurrentHealth;
        var shadowHealth = _battleDataProvider.GetShadow().entity.CurrentHealth;

        _personaHealth.text = PersonaHealth + personaHealth.ToString();
        _shadowHealth.text = ShadowHealth + shadowHealth.ToString();
    }

    private void SetUI(OnHealthChanged healthChanged)
    {
        var personaHealth = healthChanged.HealthPersona;
        var shadowHealth = healthChanged.HealthShadow;

        _personaHealth.text = PersonaHealth + personaHealth.ToString();
        _shadowHealth.text = ShadowHealth + shadowHealth.ToString();
    }
    
}
