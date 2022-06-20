namespace Apinxt.Models
{
    public record Endpoint(Guid ApiDefinitionId, string Name,
                           string Url)

    {
        public Guid UniqueId = Guid.NewGuid();
    }
}
