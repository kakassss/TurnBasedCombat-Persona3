using UnityEngine;
using UnityEngine.Serialization;

public class BattleAction : MonoBehaviour
{
    [SerializeField] private BattleDataProvider _battleDataProvider;
    [SerializeField] private BattleDataAction _battleDataAction;
    
    
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Current Entity Made his move");
            var activeEntity = _battleDataProvider.GetActiveEntity().entity;
            var deactiveEntity = _battleDataProvider.GetDeactiveEntity().entity;
            
            activeEntity.MoveAction(activeEntity,deactiveEntity);
            _battleDataAction.Swap();
            //_battleData.
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
