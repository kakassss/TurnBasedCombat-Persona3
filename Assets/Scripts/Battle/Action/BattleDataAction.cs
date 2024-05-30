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
            _data.battleDataManager.SwapTurnToEnemy();
        }

        private IEnumerator IESwapTurnCurrentEntity()
        {
            Debug.Log("Swapping to next entity");
            yield return new WaitForSeconds(1f);
            
            
            StopCoroutine(_swapCor);
        }
        
    }
}
