using System.Collections;
using System.Collections.Generic;
using SignalBus;
using UnityEngine;
using UnityEngine.UI;

public class ShadowTargetUI : MonoBehaviour
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
        _targetUIAction = new EventBinding<OnShadowTargetChanged>(SetTargetUI);
        EventBus<OnShadowTargetChanged>.Subscribe(_targetUIAction);
        
        _personaTurn = new EventBinding<OnPersonaTurn>(EnableImageUI);
        EventBus<OnPersonaTurn>.Subscribe(_personaTurn);
        
        _shadowTurn = new EventBinding<OnShadowTurn>(DisableImageUI);
        EventBus<OnShadowTurn>.Subscribe(_shadowTurn);
    }
    
    private void DisableEventBus()
    {
        EventBus<OnShadowTargetChanged>.Unsubscribe(_targetUIAction);
        EventBus<OnPersonaTurn>.Unsubscribe(_personaTurn);
        EventBus<OnShadowTurn>.Unsubscribe(_shadowTurn);
    }

    private void InitTargetImageUI()
    {
        foreach (var targetImage in _targetImages)
        {
            targetImage.gameObject.SetActive(false);
        }
        _targetImages[0].gameObject.SetActive(true);
    }
    
    private void SetTargetUI(OnShadowTargetChanged shadow)
    {
        foreach (var targetImage in _targetImages)
        {
            targetImage.gameObject.SetActive(false);
        }
        
        _targetImages[shadow.ActiveShadowIndex].gameObject.SetActive(true);
    }

    
    private void EnableImageUI()
    {
        InitTargetImageUI();
    }

    private void DisableImageUI()
    {
        foreach (var targetImage in _targetImages)
        {
            targetImage.gameObject.SetActive(false);
        }
    }
    
}
