using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class BattleUI : MonoBehaviour
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
        _personaHealth = _battleDataProvider.GetPersona().entity.CurrentHealth;
        _shadowHealth = _battleDataProvider.GetShadow().entity.CurrentMana;

        _personaHealthText.text = PersonaHealth + _personaHealth.ToString();
        _shadowHealthText.text = ShadowHealth + _shadowHealth.ToString();
    }
    
}
