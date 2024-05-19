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
            SetPersona(); // son personadaki ui kısmı değişecek mi diye koydun ---> değişti
        }
        
        if (_currentEntity != _currentEntityRound) return;
        
        _currentEntity = 0;    
        SwapTurnToEnemy();
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
    
    
    public void SwapTurnToEnemy()
    {
        _activeEntity = _activeEntity == _activePersona ? _activeShadow : _activePersona;
        SetShadow();
        SetCurrentEntityRound();
    }
    
}
