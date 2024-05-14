using UnityEngine;

namespace Defence.Character
{
    [CreateAssetMenu(fileName = "PierceCharacterBaseDefence", menuName = "ScriptableObjets/CharacterDefence/PierceCharacterDefence")]
    public class PierceCharacterBaseDefence : CharacterBaseDefence
    {
        public override void DefenceAction()
        {
            Debug.Log("This character has " + Stat + " " + DefenceTypes + " defence");
        }
    }
}