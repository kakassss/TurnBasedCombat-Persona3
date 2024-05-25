using System.Collections;
using System.Collections.Generic;
using Battle.Action;
using SignalBus;
using UnityEngine;
using UnityEngine.UI;

public class PersonaTargetUI : MonoBehaviour
{
    [SerializeField] private List<Image> _targetImages;
    private EventBinding<OnShadowTargetChanged> _targetUIAction;
    private EventBinding<OnPersonaTurn> _personaTurn;
    private EventBinding<OnShadowTurn> _shadowTurn;

    private void OnEnable()
    {
        EnableEventBus();

        InitTargetImageUI();
    }
    
    private void OnDisable()
    {
        DisableEventBus();
    }

    private void EnableEventBus()
    {
        _personaTurn = new EventBinding<OnPersonaTurn>(EnableImageUI);
        EventBus<OnPersonaTurn>.Subscribe(_personaTurn);
        
        _shadowTurn = new EventBinding<OnShadowTurn>(DisableImageUI);
        EventBus<OnShadowTurn>.Subscribe(_shadowTurn);
    }
    
    private void DisableEventBus()
    {
        EventBus<OnPersonaTurn>.Unsubscribe(_personaTurn);
        EventBus<OnShadowTurn>.Unsubscribe(_shadowTurn);
    }

    private void InitTargetImageUI()
    {
        foreach (var targetImage in _targetImages)
        {
            targetImage.gameObject.SetActive(false);
        }
        _targetImages[BattleDataProvider.ActivePersonaIndex].gameObject.SetActive(true);
    }
    
    private void SetTargetUI()
    {
        foreach (var targetImage in _targetImages)
        {
            targetImage.gameObject.SetActive(false);
        }
        
        _targetImages[BattleDataProvider.ActivePersonaIndex].gameObject.SetActive(true);
    }

    
    private void EnableImageUI()
    {
        InitTargetImageUI();
        SetTargetUI();
    }

    private void DisableImageUI()
    {
        foreach (var targetImage in _targetImages)
        {
            targetImage.gameObject.SetActive(false);
        }
    }
}
