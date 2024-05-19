using UnityEngine;

public class BattleDataAction : MonoBehaviour
{
    [SerializeField] private BattleDataProvider _data;

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
}
