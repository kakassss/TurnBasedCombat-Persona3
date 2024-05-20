using System.Collections.Generic;
using BaseEntity;
using Interfaces;
using SignalBus;
using UnityEngine;

public class BattleData : MonoBehaviour
{
    [SerializeField] private List<Shadow> _allShadows;
    [SerializeField] private List<Persona> _allPersona;
    
    private List<IMove> _iAllPersonas = new List<IMove>();
    private List<IMove> _iAllShadows = new List<IMove>();
    
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
    
    public List<IMove> GetAllPersonas()
    {
        return _iAllPersonas;
    }
    
    public List<IMove> GetAllShadows()
    {
        return _iAllShadows;
    }
    
    private void Awake()
    {
        SetEntities();
        
        _personaCount = _allPersona.Count;
        _shadowCount = _allShadows.Count;
        
        SetPersona();
    }

    private void SetEntities()
    {
        foreach (var persona in _allPersona)
        {
            _iAllPersonas.Add(persona);    
        }
        
        foreach (var shadow in _allShadows)
        {
            _iAllShadows.Add(shadow);    
        }
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
