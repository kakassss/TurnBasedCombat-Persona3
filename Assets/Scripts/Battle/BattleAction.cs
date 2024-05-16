using UnityEngine;

public class BattleAction : MonoBehaviour
{
    [SerializeField] private BattleDataProvider _battleData;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Current Entity Made his move");
            var activeEntity = _battleData.GetActiveEntity().entity;
            var deactiveEntity = _battleData.GetDeactiveEntity().entity;
            
            activeEntity.MoveAction(deactiveEntity,activeEntity);
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
