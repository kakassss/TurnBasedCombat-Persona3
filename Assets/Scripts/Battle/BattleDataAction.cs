using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleDataAction : MonoBehaviour
{
    [SerializeField] private BattleDataProvider _data;

    public void Swap()
    {
        _data.BattleData.SwapTurn();
    }
}
