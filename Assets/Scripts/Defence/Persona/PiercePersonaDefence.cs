using UnityEngine;

namespace Defence.Persona
{
    [CreateAssetMenu(fileName = "PiercePersonaDefence", menuName = "ScriptableObjets/PersonaDefence/PiercePersonaDefence")]
    public class PiercePersonaDefence : PersonaDefence
    {
        public DefenceTypes DefenceTypes => DefenceTypes.Normal;
        public Stat Stat => Stat.Pierce;
    
        public override void DefenceAction()
        {
            Debug.Log("This persona has " + Stat + " " + DefenceTypes + " defence");
        }
    }
}