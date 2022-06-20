namespace Apinxt.Models
{
    public class Request
    {
        public Request(Guid endpointId, string Name,
                          string Method,
                          string Url,
                          dynamic Body)
        {

        }
        public Guid UniqueId = Guid.NewGuid();
    }
}
