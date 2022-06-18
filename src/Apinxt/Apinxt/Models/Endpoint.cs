namespace Apinxt.Models
{
    public record Endpoint(string Name,
                           string Url,
                           IReadOnlyList<Request> Requests)

    {
        public Guid UniqueId = Guid.NewGuid();
    }
}
