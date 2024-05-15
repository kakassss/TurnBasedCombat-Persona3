using UnityEngine;

namespace Defence.Shadow
{
    [CreateAssetMenu(fileName = "SlashShadowDefence", menuName = "ScriptableObjets/ShadowDefence/SlashShadowDefence")]
    public class SlashShadowDefence : ShadowBaseDefence
    {
        public override void DefenceAction()
        {
            Debug.Log("This character has " + Stat + " " + DefenceTypes + " defence");
        }
    }
}