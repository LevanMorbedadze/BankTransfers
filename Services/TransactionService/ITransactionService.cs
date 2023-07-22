

namespace BankTransfers.Services.TransactionService
{
    public interface ITransactionService
    {
        Task<ServiceResponse<List<GetTransactionDto>>> GetAllTransaction();
        Task<ServiceResponse<GetTransactionDto>> GetTransactionById(int id);
        Task<ServiceResponse<GetTransactionDto>> AddTransaction(AddTransactionDto newTransaction, int debitAccountID, int creditAccountID);
        Task<ServiceResponse<GetTransactionDto>> UpdateTransaction(UpdateTransactionDto newTransaction);
        Task<ServiceResponse<List<GetTransactionDto>>> DeleteTransaction(int Id);
    }
}


