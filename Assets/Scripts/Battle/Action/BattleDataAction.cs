using System.Collections;
using UnityEngine;

namespace Battle.Action
{
    public class BattleDataAction : MonoBehaviour
    {
        [SerializeField] private BattleDataProvider _data;

        private Coroutine _swapCor;
        public void Swap()
        {
            if (_data.BattleData.GetCurrentEntityCount() == 1)
            {
                _data.BattleData.SwapTurnToEnemy(); 
            }
            else
            {
                _data.BattleData.SwapTurnCurrentEntity();
            }
        }

        private IEnumerator IESwapTurnCurrentEntity()
        {
            Debug.Log("Swapping to next entity");
            yield return new WaitForSeconds(1f);
            
            
            StopCoroutine(_swapCor);
        }
        
    }
}
