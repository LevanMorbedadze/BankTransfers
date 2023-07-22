

namespace BankTransfers.Services.ClientService
{
    public interface IClientService
    {
        Task<ServiceResponse<List<GetClientDto>>> GetAllClients();
        Task<ServiceResponse<GetClientDto>> GetClientById(int id);
        Task<ServiceResponse<GetClientDto>> AddClient(AddClientDto newClient);
        //Task<ServiceResponse<GetAccountDto>> UpdateAccount(UpdateAccountDto newAccount);
        //Task<ServiceResponse<List<GetAccountDto>>> DeleteAccount(int id);
    }
}
