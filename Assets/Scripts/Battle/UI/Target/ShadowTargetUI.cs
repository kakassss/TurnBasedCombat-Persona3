using System.Collections;
using System.Collections.Generic;
using SignalBus;
using UnityEngine;
using UnityEngine.UI;

public class ShadowTargetUI : MonoBehaviour
{
    [SerializeField] private List<Image> _targetImages;
    private EventBinding<OnShadowTargetChanged> _targetUIAction;

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
    }
    
    private void DisableEventBus()
    {
        EventBus<OnShadowTargetChanged>.Unsubscribe(_targetUIAction);
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
    
}
