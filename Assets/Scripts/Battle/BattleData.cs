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
    
    public IMove GetActivePersona => _activePersona;
    public IMove GetActiveShadow => _activeShadow;
    
    
    private void Awake()
    {
        SetBattleData();
    }

    private void SetBattleData()
    {
        _activePersona = _allPersona[0];
        _activeShadow = _allShadows[0];
    }
    
    public void SwapTurn()
    {
        (_activePersona, _activeShadow) = (_activeShadow, _activePersona);
    }
    
}
