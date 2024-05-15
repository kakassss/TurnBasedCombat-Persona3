using UnityEngine;

namespace Defence.Shadow
{
    [CreateAssetMenu(fileName = "StrikeShadowDefence", menuName = "ScriptableObjets/ShadowDefence/StrikeShadowDefence")]
    public class StrikeShadowDefence : ShadowBaseDefence
    {
        public override void DefenceAction()
        {
            Debug.Log("This character has " + Stat + " " + DefenceTypes + " defence");
        }
    }
}