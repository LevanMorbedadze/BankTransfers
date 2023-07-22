

namespace BankTransfers.Services.TransactionService
{
    public class TransactionService : ITransactionService
    {
        private readonly BankTransfersContext _context;
        private readonly IMapper _mapper;

        public TransactionService(BankTransfersContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<GetTransactionDto>> AddTransaction(AddTransactionDto newTransaction, int debitAccountID, int creditAccountID)
        {
            var dbTransaction = _mapper.Map<Transaction>(newTransaction);//aq daemata
            dbTransaction.DebitAccountId = debitAccountID;               //aq daemata
            dbTransaction.CreditAccountId = creditAccountID;             //aq daemata
            //dbTransaction.CommisionsId = commisionsID;
            Commission commission = new Commission()
            {
                TransferFee = 1,
                CommissionIncome = 2

            };
            dbTransaction.Commisions = commission;
            
             
            _context.Transactions.Add(dbTransaction);
            _context.SaveChanges();
            var getTransactionDto = _mapper.Map<GetTransactionDto>(dbTransaction);
            var serviceresponse = new ServiceResponse<GetTransactionDto>();
            serviceresponse.Date = getTransactionDto;
            return serviceresponse;
        }

        public async Task<ServiceResponse<List<GetTransactionDto>>> DeleteTransaction(int Id)
        {
            var response = new ServiceResponse<List<GetTransactionDto>>();
            var dbTransaction = await _context.Transactions.FirstOrDefaultAsync(x => x.Id == Id);
            if (dbTransaction == null)
            {
                response.success = false;
                response.Message = "transaction not found";
                throw new Exception("transaction not found");
            }
            else
            {
                _context.Transactions.Remove(dbTransaction);
                _context.SaveChanges();
            }
            var dbTransactions = await _context.Transactions.ToListAsync();
            var getTransactionDto = dbTransactions.Select(x => _mapper.Map<GetTransactionDto>(x)).ToList();
            response.Date = getTransactionDto;
            return response;
        }

        public async Task<ServiceResponse<List<GetTransactionDto>>> GetAllTransaction()
        {
            var response = new ServiceResponse<List<GetTransactionDto>>();
            var dbTransaction = await _context.Transactions.ToListAsync();
            var getTransactionDto = dbTransaction.Select(x => _mapper.Map<GetTransactionDto>(x)).ToList();
            response.Date = getTransactionDto;
            return response;
        }

        public async Task<ServiceResponse<GetTransactionDto>> GetTransactionById(int id)
        {
            var response = new ServiceResponse<GetTransactionDto>();
            var dbTransaction = await _context.Transactions.FirstOrDefaultAsync(x => x.Id == id);
            if (dbTransaction == null)
            {
                response.success = false;
                response.Message = "transaction not found";
                throw new Exception("transaction not found");
            }
            var getTransactionDto = _mapper.Map<GetTransactionDto>(dbTransaction);
            response.Date = getTransactionDto;
            return response;
        }

        public async Task<ServiceResponse<GetTransactionDto>> UpdateTransaction(UpdateTransactionDto newTransaction)
        {
            var response = new ServiceResponse<GetTransactionDto>();
            var dbTransaction = await _context.Transactions.FirstOrDefaultAsync(x => x.Id == newTransaction.Id);
            if (dbTransaction == null)
            {
                response.success = false;
                response.Message = "transaction not found";
                throw new Exception("transaction not found");
            }
            dbTransaction.DebitAmount = dbTransaction.DebitAmount;
            dbTransaction.CreditAmount = dbTransaction.CreditAmount;
            dbTransaction.BalanceBefore = dbTransaction.BalanceBefore;
            dbTransaction.BalanceAfter = dbTransaction.BalanceAfter;
            dbTransaction.DetailsOfTransactions = dbTransaction.DetailsOfTransactions;
            dbTransaction.Date = dbTransaction.Date;


            var getTransactionDto = _mapper.Map<GetTransactionDto>(dbTransaction);
            await _context.SaveChangesAsync();
            response.Date = getTransactionDto;
            return response;
        }

    }            
}
