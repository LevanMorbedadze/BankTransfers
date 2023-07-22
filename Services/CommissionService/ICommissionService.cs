

namespace BankTransfers.Services.CommissionService
{
    public interface ICommissionService
    {
        Task<ServiceResponse<List<GetCommissionDto>>> GetAllCommission();
        Task<ServiceResponse<GetCommissionDto>> GetCommissionById(int id);
        Task<ServiceResponse<GetCommissionDto>> AddCommision(AddCommissionDto newCommission);
        Task<ServiceResponse<GetCommissionDto>> UpdateCommision(UpdateCommissionDto newCommission);
    }
}
