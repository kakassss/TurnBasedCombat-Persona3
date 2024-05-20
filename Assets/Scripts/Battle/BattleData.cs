using System.Collections.Generic;
using BaseEntity;
using Interfaces;
using SignalBus;
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
    }

    private void SetPersona()
    {
        _activePersona = _allPersona[_currentEntity];
        _activeEntity = _activePersona;
        _currentEntityRound = _personaCount -1;
    }

    private void SetShadow()
    {
        _activeShadow = _allShadows[_currentEntity];
        _activeEntity = _activeShadow;
        _currentEntityRound = _shadowCount -1;
        EventBus<OnShadowTurn>.Fire(new OnShadowTurn());
    }
    
    private void SetEntity(IMove entity)
    {
        if (entity == _activePersona)
        {
            SetPersona();
        }
        else
        {
            SetShadow();
        }
    }
    
    public void SwapTurnCurrentEntity()
    {
        if (_currentEntity == _currentEntityRound)
        {
            _currentEntity = 0;    
            SwapTurnToEnemy();
        }
        
        if (_currentEntity < _currentEntityRound)
        {
            _currentEntity++;
            SetEntity(_activeEntity);
        }
        
    }
    
    public void SwapTurnToEnemy()
    {
        _activeEntity = _activeEntity == _activePersona ? _activeShadow : _activePersona;
        SetEntity(_activeEntity);
    }
}
