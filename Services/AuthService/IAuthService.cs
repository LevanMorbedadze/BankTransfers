namespace BankTransfers.Services.AuthService
{
    public interface IAuthService
    {
         
        Task<Client> Register(Client user, string password);
        Task<Client> Login(string username, string password);
        Task<bool> UserExists(string email);
    }
}

