namespace Apinxt.Models
{
    public record ApiDefinition(
        string Name,
        string UrlBase,
        Dictionary<string, string> Headers,
        IReadOnlyList<Endpoint> Endpoints)
    {
        public Guid UniqueId = Guid.NewGuid();
    }
}
