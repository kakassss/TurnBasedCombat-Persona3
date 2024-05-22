using Battle.Action;
using UnityEngine;

namespace Defence.DefenceAction
{
    public abstract class EntityDefenceAction : MonoBehaviour
    {
        protected BattleDataProvider _battleDataProvider;
        private void Awake()
        {
            _battleDataProvider = FindObjectOfType<BattleDataProvider>();
        }
    }
}
