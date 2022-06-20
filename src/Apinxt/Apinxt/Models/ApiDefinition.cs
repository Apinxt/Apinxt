namespace Apinxt.Models
{
    public record ApiDefinition(
        string Name,
        string UrlBase,
        Dictionary<string, string> Headers)
    {
        public Guid UniqueId = Guid.NewGuid();
    }
}
