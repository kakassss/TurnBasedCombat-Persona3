using UnityEngine;

namespace Defence.Character
{
    [CreateAssetMenu(fileName = "StrikeCharacterDefence", menuName = "ScriptableObjets/CharacterDefence/StrikeCharacterDefence")]
    public class StrikeCharacterDefence : CharacterDefence
    {
        public Stat Stat => Stat.Slash;
        public DefenceTypes DefenceTypes => DefenceTypes.Reflect;
    
        public override void DefenceAction()
        {
            Debug.Log("This character has " + Stat + " " + DefenceTypes + " defence");
        }
    }
}