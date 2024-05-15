using UnityEngine;

namespace Defence.Shadow
{
    [CreateAssetMenu(fileName = "PierceShadowDefence", menuName = "ScriptableObjets/ShadowDefence/PierceShadowDefence")]
    public class PierceShadowDefence : ShadowBaseDefence
    {
        public override void DefenceAction()
        {
            Debug.Log("This character has " + Stat + " " + DefenceTypes + " defence");
        }
    }
}