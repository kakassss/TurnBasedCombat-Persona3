namespace Interfaces.Stats
{
    public interface IConsumableItem
    {
        string ItemName {get;}
        int ItemValue { get; }
        void ItemAction(IMove activeEntity);
    }
}