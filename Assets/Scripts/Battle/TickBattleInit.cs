using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using BaseEntity;
using Interfaces;
using UnityEngine;
using Random = UnityEngine.Random;

public class TickBattleInit : MonoBehaviour
{
    [SerializeField] private List<Shadow> _allShadows;
    [SerializeField] private List<Persona> _allPersona;

    private IMove _activeEntity;
    private IMove _deactiveEntity;
    
    private void Start()
    {
        BattleAction();
        
    }
    
    private void BattleAction()
    {
        if (_activeEntity == null)
        {
            int select = Random.Range(0,2);
            bool random = select == 0;;

            
            _activeEntity = random ? _allShadows[0] : _allPersona[0];
            _deactiveEntity = !random ? _allShadows[0] : _allPersona[0];
            
            
            Debug.Log("Active Entity " + _activeEntity.GetType().Name);
            Debug.Log("Deactive Entity " + _deactiveEntity.GetType().Name);
        }
        
        Debug.Log("aa " + _deactiveEntity.entity.CurrentHealth);
        
        
        Debug.Log("Current Entity Ready for his Move!");
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Current Entity Made his move");
            _activeEntity.MoveAction(_deactiveEntity,_activeEntity);
        }
    }


    private void SwapTurn()
    {
        (_activeEntity, _deactiveEntity) = (_deactiveEntity, _activeEntity);
    }
    /*
     *
     * bütün düşmanları ve karakterleri belirle
     *
     * tur sırası kimdeyse ondan başlat
     * kamerayı ayarla(olacaksa)
     *
     *
     *
     *
     *
     */



}
