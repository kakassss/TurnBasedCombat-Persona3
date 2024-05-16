using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Entity;
using Interfaces;
using UnityEngine;
using Random = UnityEngine.Random;

public class TickBattleInit : MonoBehaviour
{
    [SerializeField] private List<Shadow> _allShadows;
    [SerializeField] private List<Persona> _allPersona;

    private IActiveEntity _activeEntity;

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
            
            Debug.Log("Current Entity1 " + _activeEntity.GetType().Name);
        }
        
        Debug.Log("Current Entity Ready for his Move!");
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Current Entity Made his move");
            _activeEntity.MoveAction();
        }
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
