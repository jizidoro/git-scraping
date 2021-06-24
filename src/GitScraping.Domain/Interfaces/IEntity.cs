namespace GitScraping.Domain.Interfaces
{
    public interface IEntity
    {
        int Id { get; }
        int Key { get; }
        string Value { get; }
    }
}