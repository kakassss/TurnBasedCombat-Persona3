using UnityEngine;

public class BattleDataAction : MonoBehaviour
{
    [SerializeField] private BattleDataProvider _data;

    public void Swap()
    {
        if (_data.BattleData.GetCurrentEntityCount() == 1)
        {
            _data.BattleData.SwapTurnToEnemy(); 
            Debug.Log("onur 2");
        }
        else
        {
            Debug.Log("onur 3");
            _data.BattleData.SwapTurnCurrentEntity();
        }
    }
}
