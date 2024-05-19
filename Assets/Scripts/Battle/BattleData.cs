using System.Collections.Generic;
using BaseEntity;
using Interfaces;
using UnityEngine;

public class BattleData : MonoBehaviour
{
    [SerializeField] private List<Shadow> _allShadows;
    [SerializeField] private List<Persona> _allPersona;
    
    private IMove _activeEntity;
    private IMove _activePersona;
    private IMove _activeShadow;
    
    private int _personaCount;
    private int _shadowCount;
    private int _currentEntityRound;
    private int _currentEntity = 0;
    
    public IMove GetActivePersona => _activePersona;
    public IMove GetActiveShadow => _activeShadow;
    public IMove GetActiveEntity => _activeEntity;
    
    public int GetCurrentEntityCount()
    {
        return _currentEntityRound;
    }
    
    private void Awake()
    {
        _personaCount = _allPersona.Count;
        _shadowCount = _allShadows.Count;
        _activeShadow = _allShadows[0];
        
        SetPersona();
        SetCurrentEntityRound();
    }

    private void SetPersona()
    {
        _activePersona = _allPersona[_currentEntity];
        _activeEntity = _activePersona;
    }

    private void SetShadow()
    {
        _activeShadow = _allShadows[_currentEntity];
        _activeEntity = _activeShadow;
    }
    
    private void SetCurrentEntityRound()
    {
        if (_activeEntity == _activePersona)
        {
            _currentEntityRound = _personaCount;
        }
        else if (_activeEntity == _activeShadow)
        {
            _currentEntityRound = _shadowCount;
        }
    }
    
    public void SwapTurnCurrentEntity()
    {
        if (_currentEntity < _currentEntityRound)
        {
            _currentEntity++;
            Debug.Log("onur y " + _currentEntity);
        }

        if (_currentEntity == _currentEntityRound)
        {
            _currentEntity = 0;    
            SwapTurnToEnemy();
            Debug.Log("onur 1");
        }
        

    }
    
    public void SwapTurnToEnemy()
    {
        _activeEntity = _activeEntity == _activePersona ? _activeShadow : _activePersona;
        SetShadow();
        SetCurrentEntityRound();
        Debug.Log("onur ac2 " + _activeEntity);
    }
    
}
