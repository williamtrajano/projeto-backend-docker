namespace Ambev.Domain.Services
{
    public interface IAuthService
    {
        Task<string> Authenticate(string email, string password);
    }
}
