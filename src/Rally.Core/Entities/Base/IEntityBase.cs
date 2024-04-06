namespace Rally.Core.Entities.Base
{
    public interface IEntityBase<TId>
    {
        TId Id { get; }
    }
}
