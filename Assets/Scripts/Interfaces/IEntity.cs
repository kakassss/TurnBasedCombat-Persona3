using BaseEntity;

namespace Interfaces
{
    public interface IEntity
    {
        void SetEntityData();
    }
    public interface IMove
    {
        Entity entity { get; }
        void MoveAction(IMove activeEntity,IMove deactiveEntity);
    }
}