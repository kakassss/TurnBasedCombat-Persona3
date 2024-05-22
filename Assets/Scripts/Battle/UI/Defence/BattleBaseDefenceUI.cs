using System.Collections.Generic;
using Battle.Action;
using SignalBus;
using TMPro;
using UnityEngine;

public abstract class BattleBaseDefenceUI : MonoBehaviour, ITakeDamage
{
    [SerializeField] protected List<TextMeshProUGUI> _defenceTexts;
    protected BattleDataProvider _battleDataProvider;
    private EventBinding<OnTakeDamage> _defenceAction;

    private void Awake()
    {
        _battleDataProvider = FindObjectOfType<BattleDataProvider>();
    }

    protected virtual void OnEnable()
    {
        EnableEventBus();
    }
    
    protected virtual void OnDisable()
    {
        DisableEventBus();
    }
    
    private void EnableEventBus()
    {
        _defenceAction = new EventBinding<OnTakeDamage>(TakeDamage);
        EventBus<OnTakeDamage>.Subscribe(_defenceAction);
    }

    private void DisableEventBus()
    {
        EventBus<OnTakeDamage>.Unsubscribe(_defenceAction);
    }

    protected void SetActiveEntityText(string text,int index)
    {
        _defenceTexts[index].text = text;
    }
    
    protected void OpenActiveEntityText(int index)
    {
        _defenceTexts[index].gameObject.SetActive(true);
    }

    protected void CloseAllTexts()
    {
        foreach (var text in _defenceTexts)
        {
            text.gameObject.SetActive(false);
        }
    }
    
    public abstract void TakeDamage(OnTakeDamage deactiveEntity);
}
