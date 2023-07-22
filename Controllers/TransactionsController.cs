using BankTransfers.Services.TransactionService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BankTransfers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly BankTransfersContext _context;
        private readonly ITransactionService _transactionService;

        public TransactionsController(BankTransfersContext context, ITransactionService transactionService)
        {
            _context = context;
            _transactionService = transactionService;
        }

        [Route("GetAll")]
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetTransactionDto>>>> getall()
        {
            return await _transactionService.GetAllTransaction();
            //BankTransfersContext db = new BankTransfersContext();
            //var transactions = db.Transactions.ToList();
            //return transactions;
        }

        [Route("GetSingle")]
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<GetTransactionDto>>> getsingle(int id)
        {
            return await _transactionService.GetTransactionById(id);
            //BankTransfersContext db = new BankTransfersContext();
            //var transactions = db.Transactions.FirstOrDefault(a => a.Id == id);
            //return transactions;
        }
        [Authorize]
        [Route("Add")]
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetTransactionDto>>> Post(AddTransactionDto transaction)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int debitAccountID = Convert.ToInt32(userId);           
            int creditAccountID = Convert.ToInt32(userId);           
            int commisionsID = Convert.ToInt32(userId);           
            return await _transactionService.AddTransaction(transaction, debitAccountID,creditAccountID, commisionsID);
            //BankTransfersContext db = new BankTransfersContext();
            //db.Transactions.Add(transaction);
            //db.SaveChanges();
            //return "transaction added";


        }
        [Route("Update")]
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetTransactionDto>>> put(UpdateTransactionDto updateTransactionDto)
        {
            return await _transactionService.UpdateTransaction(updateTransactionDto);
            //BankTransfersContext db = new BankTransfersContext();
            //var transactionFromBase = db.Transactions.FirstOrDefault(a => a.Id == transaction.Id);
            //if (transactionFromBase != null)
            //{
            //    transactionFromBase.DebitAmount = transaction.DebitAmount;
            //    transactionFromBase.CreditAmount = transaction.CreditAmount;
            //    transactionFromBase.BalanceBefore = transaction.BalanceBefore;
            //    transactionFromBase.BalanceAfter = transaction.BalanceAfter;
            //    transactionFromBase.DetailsOfTransactions = transaction.DetailsOfTransactions;                
            //    db.SaveChanges();
            //    return "transaction updated";
            //}
            //return "transaction not found";
        }
        [Route("Delete")]
        [HttpDelete]
        public async Task<ServiceResponse<List<GetTransactionDto>>> Delete(int Id)
        {
            return await _transactionService.DeleteTransaction(Id);

            //BankTransfersContext db = new BankTransfersContext();
            //var transactions = db.Transactions.FirstOrDefault(a => a.Id == id);
            //if (transactions != null)
            //{
            //    db.Transactions.Remove(transactions);
            //    db.SaveChanges();
            //    return "transactions Deleteed";
            //}
            //return "transactions not found";

        }
    }
}



