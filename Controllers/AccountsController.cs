using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BankTransfers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly BankTransfersContext _context;
        private readonly IAccountService _accountService;

        public AccountsController(BankTransfersContext context, IAccountService accountService)
        {
            _context = context;
            _accountService = accountService;
        }
        [Route("GetAll")]
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetAccountDto>>>> getall()
        {
            return await _accountService.GetAllAccounts();

            //BankTransfersContext db = new BankTransfersContext();
            //var accounts = db.Accounts.ToList();
            //return accounts;
        }
        [Route("GetSingle")]
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<GetAccountDto>>> getsingle(int id)
        {
            return await _accountService.GetAccountById(id);
            //var DbAccounts = _context.Accounts.FirstOrDefault(a => a.Id == id);
            //GetAccountDto getAccountDto = new GetAccountDto();
            //getAccountDto.Id = DbAccounts.Id;
            //getAccountDto.AccountNumber = DbAccounts.AccountNumber;
            //getAccountDto.Currency = DbAccounts.Currency;
            //getAccountDto.Balance = DbAccounts.Balance;
            //getAccountDto.ClientId = DbAccounts.ClientId;
            //ServiceResponse<GetAccountDto> response = new();
            //response.Date = getAccountDto;
            //return response;
        }

        [Authorize]
        [Route("Add")]
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetAccountDto>>> Post(AddAccountDto account)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int clientId = Convert.ToInt32(userId);

            return await _accountService.AddAccount(account, clientId);
        }
        [Route("Update")]
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetAccountDto>>> put(UpdateAccountDto updateAccountDto)
        {
            return await _accountService.UpdateAccount(updateAccountDto);
            //BankTransfersContext db = new BankTransfersContext();
            //var accountsFromBase = db.Accounts.FirstOrDefault(a => a.Id == account.Id);
            //if (accountsFromBase != null)
            //{
            //    accountsFromBase.AccountNumber = account.AccountNumber;
            //    accountsFromBase.Currency = account.Currency;
            //    accountsFromBase.Balance = account.Balance;
            //    accountsFromBase.ClientId = account.ClientId;
            //    db.SaveChanges();
            //    return "account updated";
            //}
            //return "account not found";
        }
        [Route("Delete{id}")]
        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<GetAccountDto>>>> Delete(int id)
        {
            return await _accountService.DeleteAccount(id);
            //BankTransfersContext db = new BankTransfersContext();
            //var accunts = db.Accounts.FirstOrDefault(a => a.Id == id);
            //if (accunts != null)
            //{
            //    db.Accounts.Remove(accunts);
            //    db.SaveChanges();
            //    return "account Deleteed";
            //}
            //return "account not found";

        }

    }
}
