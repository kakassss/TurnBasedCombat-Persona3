using UnityEngine;

namespace Defence.Character
{
    [CreateAssetMenu(fileName = "PierceCharacterDefence", menuName = "ScriptableObjets/CharacterDefence/PierceCharacterDefence")]
    public class PierceCharacterDefence : CharacterDefence
    {
        public Stat Stat => Stat.Slash;
        public DefenceTypes DefenceTypes => DefenceTypes.Reflect;
    
        public override void DefenceAction()
        {
            Debug.Log("This character has " + Stat + " " + DefenceTypes + " defence");
        }
    }
}