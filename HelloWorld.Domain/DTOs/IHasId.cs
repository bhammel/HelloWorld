namespace HelloWorld.Domain.DTOs
{
    public interface IHasId<T>
    {
        T Id { get; set; }
    }
}
