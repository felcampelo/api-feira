namespace fair.domain.Entities.Base
{
    public interface IBaseEntity<T>
    {
        T Id { get; }
    }
}
