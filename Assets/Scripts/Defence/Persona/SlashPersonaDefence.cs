using UnityEngine;

namespace Defence.Persona
{
    [CreateAssetMenu(fileName = "SlashPersonaDefence", menuName = "ScriptableObjets/PersonaDefence/SlashPersonaDefence")]
    public class SlashPersonaDefence : PersonaDefence
    {
        public Stat Stat => Stat.Slash;
        public DefenceTypes DefenceTypes => DefenceTypes.Reflect;
    
        public override void DefenceAction()
        {
            Debug.Log("This persona has " + Stat + " " + DefenceTypes + " defence");
        }
    }
}