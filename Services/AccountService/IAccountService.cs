

namespace BankTransfers.Services.AccountService
{
    public interface IAccountService
    {
        Task<ServiceResponse<List<GetAccountDto>>> GetAllAccounts();
        Task<ServiceResponse<GetAccountDto>> GetAccountById(int id);
        Task<ServiceResponse<GetAccountDto>> AddAccount(AddAccountDto newAccount, int clientId);
        Task<ServiceResponse<GetAccountDto>> UpdateAccount(UpdateAccountDto newAccount);
        Task<ServiceResponse<List<GetAccountDto>>> DeleteAccount(int id);
        
    }
}
