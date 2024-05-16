using System;
using System.Collections;
using System.Collections.Generic;
using BaseEntity;
using Interfaces;
using UnityEngine;
using Random = UnityEngine.Random;

public class BattleData : MonoBehaviour
{
    [SerializeField] private List<Shadow> _allShadows;
    [SerializeField] private List<Persona> _allPersona;
    
    private IMove _activeEntity;
    private IMove _deactiveEntity;

    private IMove _persona;
    private IMove _shadow;

    public IMove GetActiveEntity => _activeEntity;
    public IMove GetDeactiveEntity => _deactiveEntity;
    public IMove GetPersona => _persona;
    public IMove GetShadow => _shadow;
    
    
    private void Awake()
    {
        SetBattleData();
    }

    private void SetBattleData()
    {
        int select = Random.Range(0,2);
        bool random = select == 0;;

        _persona = _allPersona[0];
        _shadow = _allShadows[0];
            
        _activeEntity = random ? _allShadows[0] : _allPersona[0];
        _deactiveEntity = !random ? _allShadows[0] : _allPersona[0];
            
            
        Debug.Log("Active Entity " + _activeEntity.GetType().Name);
        Debug.Log("Deactive Entity " + _deactiveEntity.GetType().Name);
    }
    
    private void SwapTurn()
    {
        (_activeEntity, _deactiveEntity) = (_deactiveEntity, _activeEntity);
    }
    
}
