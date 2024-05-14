public abstract class CharacterBaseAbilities : EntityBaseAbilities, ICharacterAbilities
{
    public Stat Stat => _stat;
    
    public virtual void AbilityAction()
    {
        
    }
}