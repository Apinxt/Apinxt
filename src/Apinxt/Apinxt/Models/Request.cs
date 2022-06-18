namespace Apinxt.Models
{
    public record Request(string Name,
                          HttpMethod Method,
                          string Url)
    {
        public Guid UniqueId = Guid.NewGuid();
    }
}
