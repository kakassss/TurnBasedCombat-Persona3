using System.Collections.Generic;
using BaseEntity;
using Interfaces;
using SignalBus;
using UnityEngine;

namespace Battle.Action
{
    public class BattleDataShadow
    {
        public IMove ActiveShadow;
        
        private List<IMove> _allPlayableShadows = new List<IMove>(); // To select
        private List<IMove> _allShadows = new List<IMove>(); // To shadow all foe attack
        
        private int _shadowsTotalCount;
        private int _shadowCurrentEntity;
        private int _shadowTotalPlayableCount;
        
        public List<IMove> GetAllShadows()
        {
            return _allShadows;
        }

        //It needs total count of shadows not playables
        public int GetAllShadowCount()
        {
            return _shadowsTotalCount;
        }
        
        public void InitShadow(List<Shadow> allShadow)
        {
            SetShadowsList(allShadow);
            
            SetPlayableShadowsData();
        }

        private void SetShadowsList(List<Shadow> allShadow)
        {
            foreach (var shadow in allShadow)
            {
                _allShadows.Add(shadow);
                if (shadow.isDisable == false)
                {
                    _allPlayableShadows.Add(shadow);
                }
            }

            _shadowsTotalCount = _allShadows.Count;
            _shadowTotalPlayableCount = _allPlayableShadows.Count;
        }

        private void SetPlayableShadowsData()
        {
            SetShadowData();
        }

        private void SetPlayableShadows()
        {
            SetShadowData();
            SetActiveShadow();
        }
        
        private void SetShadowData()
        {
            ActiveShadow = _allPlayableShadows[_shadowCurrentEntity];
            BattleDataProvider.ActiveShadowIndex = _shadowCurrentEntity;
        }
        
        private void SetActiveShadow()
        {
            BattleDataManager.ActiveEntity = ActiveShadow;
            _shadowTotalPlayableCount = _shadowsTotalCount -1;
            Debug.Log("onur active shadow 1");
            EventBus<OnShadowTurn>.Fire(new OnShadowTurn());
            Debug.Log("onur active shadow 2");
        }
        
        public void SwapCurrentShadow()
        {
            if (_shadowCurrentEntity == _shadowTotalPlayableCount)
            {
                _shadowCurrentEntity = 0;
                Debug.Log("onur active shadow 1?");
                EventBus<OnTurnEntity>.Fire(new OnTurnEntity()); //Persona Turn
                return;
            }

            if (_shadowCurrentEntity < _shadowTotalPlayableCount)
            {
                _shadowCurrentEntity++;
                Debug.Log("onur active shadow 2?");
                SetPlayableShadows();
            }
        }
        
    }
}
