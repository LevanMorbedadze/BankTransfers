

namespace BankTransfers.Services.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly BankTransfersContext _context;
        private readonly IMapper _mapper;

        public AccountService(BankTransfersContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<GetAccountDto>> AddAccount(AddAccountDto newAccount, int clientId)
        {
            var dbAccount = _mapper.Map<Account>(newAccount);
            dbAccount.ClientId = clientId;
            _context.Accounts.Add(dbAccount);
            _context.SaveChanges();
            var getAccountDto = _mapper.Map<GetAccountDto>(dbAccount);
            var serviceresponse = new ServiceResponse<GetAccountDto>();
            serviceresponse.Date = getAccountDto;
            return serviceresponse;       

        }

        public async Task<ServiceResponse<List<GetAccountDto>>> DeleteAccount(int id)
        {
            var response = new ServiceResponse<List<GetAccountDto>>();
            var dbAccount = await _context.Accounts.FirstOrDefaultAsync(x => x.Id == id);
            if (dbAccount == null)
            {
                response.success = false;
                response.Message = "account not found";
                throw new Exception("account not found");
            }
            else
            {
                _context.Accounts.Remove(dbAccount);
                _context.SaveChanges();
            }
            var dbAccounts = await _context.Accounts.ToListAsync();
            var getAccountDto = dbAccounts.Select(x => _mapper.Map<GetAccountDto>(x)).ToList();
            response.Date = getAccountDto;
            return response;                     

        }

        public async Task<ServiceResponse<List<GetAccountDto>>> GetAllAccounts()
        {
            var response = new ServiceResponse<List<GetAccountDto>>();
            var dbAccounts = await _context.Accounts.ToListAsync();
            var getAccountDto = dbAccounts.Select(x => _mapper.Map<GetAccountDto>(x)).ToList();
            response.Date = getAccountDto;
            return response;          
        }

        public async Task<ServiceResponse<GetAccountDto>> GetAccountById(int id)
        {
            var response = new ServiceResponse<GetAccountDto>();
            var dbAccount = await _context.Accounts.FirstOrDefaultAsync(x => x.Id == id);
            if (dbAccount == null)
            {
                response.success = false;
                response.Message = "account not found";
                throw new Exception("account not found");
            }
            var getAccountDto = _mapper.Map<GetAccountDto>(dbAccount);
            response.Date = getAccountDto;
            return response;          
        }

        public async Task<ServiceResponse<GetAccountDto>> UpdateAccount(UpdateAccountDto newAccount)
        {
            var response = new ServiceResponse<GetAccountDto>();            
            var dbAccount = await _context.Accounts.FirstOrDefaultAsync(x => x.Id == newAccount.Id);
            if (dbAccount == null)
            {
                response.success = false;
                response.Message = "account not found";
                throw new Exception("account not found");
            }
            dbAccount.AccountNumber = newAccount.AccountNumber;
            dbAccount.Currency = newAccount.Currency;
            dbAccount.Balance = newAccount.Balance;
            dbAccount.ClientId = newAccount.ClientId;

            var getAccountDto = _mapper.Map<GetAccountDto>(dbAccount);
            await _context.SaveChangesAsync();
            response.Date = getAccountDto;
            return response;          
        }

       
    }
}



