using UnityEngine;

namespace Defence.Persona
{
    [CreateAssetMenu(fileName = "StrikePersonaDefence", menuName = "ScriptableObjets/PersonaDefence/StrikePersonaDefence")]
    public class StrikePersonaDefence : PersonaDefence
    {
        public Stat Stat => Stat.Strike;
        public DefenceTypes DefenceTypes => DefenceTypes.Normal;
    
        public override void DefenceAction()
        {
            Debug.Log("This persona has " + Stat + " " + DefenceTypes + " defence");
        }
    }
}