using BaseEntity;

namespace Interfaces
{
    public interface IMove
    {
        Entity entity { get; }
        void MoveAction();
    }
}