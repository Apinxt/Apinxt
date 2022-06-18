namespace Apinxt.Models
{
    public record ApiAssertionResult(string TestName, bool Success, string Reason, string ErrorMessage);
}
