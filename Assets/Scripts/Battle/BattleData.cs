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
    }

    private void SetPersona()
    {
        _activePersona = _allPersona[_currentEntity];
        _activeEntity = _activePersona;
        _currentEntityRound = _personaCount -1;
        Debug.Log("onur " + _currentEntity);
        Debug.Log("onurx " + _activeEntity.entity.name);
    }

    private void SetShadow()
    {
        _activeShadow = _allShadows[_currentEntity];
        _activeEntity = _activeShadow;
        _currentEntityRound = _shadowCount -1;
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
    
    /*
     * SwapTurn mekaniğinin şuan çalısma hali
     * 4 tane persona var. 4 kere action yapıyoruz sonrasında shadow listesine geçiyor
     * şuanlık shadow bi şey yapmadıgı için öyle kalıyor.
     *
     * şuanlık personalar kendi içinde dönmüyor, hep ilk persona hamle yapıyor
     * yukarıda koydugun setpersona ile test ettin, o sayede dönebiliyor ama tabi
     * buradaki kod ağır bok oldu
     * 
     */
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
        Debug.Log("onur next " + _activeEntity.entity.name);
    }
}
