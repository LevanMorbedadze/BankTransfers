using BankTransfers.Dto.CommissionDto;
using BankTransfers.Dto.TransactionDto;

namespace BankTransfers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Account, GetAccountDto>();
            CreateMap<AddAccountDto, Account>();
            CreateMap<UpdateAccountDto, Account>();

            CreateMap<Client, GetClientDto>();
            CreateMap<AddClientDto, Client>();

            CreateMap<Commission, GetCommissionDto>();
            CreateMap<AddCommissionDto, Commission>();
            CreateMap<UpdateCommissionDto, Commission>();

            CreateMap<Transaction, GetTransactionDto>();
            CreateMap<AddTransactionDto, Transaction>();
            CreateMap<UpdateTransactionDto, Transaction>();

        }
    }
}
