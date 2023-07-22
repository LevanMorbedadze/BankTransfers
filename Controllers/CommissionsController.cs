using BankTransfers.DbModels;
using BankTransfers.Dto;
using BankTransfers.Dto.AccountDto;
using BankTransfers.Dto.CommissionDto;
using BankTransfers.Services.CommissionService;
using Microsoft.AspNetCore.Mvc;

namespace BankTransfers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommissionController : ControllerBase
    {
        private readonly BankTransfersContext _context;
        private readonly ICommissionService _commissionService;

        public CommissionController(BankTransfersContext context, ICommissionService commissionService)
        {
            _context = context;
            _commissionService = commissionService;
        }
        [Route("GetAll")]
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetCommissionDto>>>> getall()
        {
            return await _commissionService.GetAllCommission();
            //var commissions = _context.Commissions.ToList();
            //return commissions;
        }
        [Route("GetSingle")]
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<GetCommissionDto>>> getsingle(int id)
        {
            return await _commissionService.GetCommissionById(id);
            //var commissions = _context.Commissions.FirstOrDefault(a => a.Id == id);
            //return commissions;
        }
      

        [Route("Add")]
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetCommissionDto>>> Post(AddCommissionDto commission)
        {
            return await _commissionService.AddCommision(commission);
            //BankTransfersContext db = new BankTransfersContext();
            //_context.Commissions.Add(commission);
            //_context.SaveChanges();
            //return "commision added";
        }
        [Route("Update")]
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetCommissionDto>>> put(UpdateCommissionDto updateCommission)
        {
            return await _commissionService.UpdateCommision(updateCommission);
            //BankTransfersContext db = new BankTransfersContext();
            //var commissionFromBase = _context.Commissions.FirstOrDefault(a => a.Id == commission.Id);
            //if (commissionFromBase != null)
            //{
            //    commissionFromBase.TransferFee = commission.TransferFee;
            //    commissionFromBase.CommissionIncome = commission.CommissionIncome;

            //    _context.SaveChanges();
            //    return "commision updated";
            //}
            //return "commision not found";
        }
        //[Route("Delete")]
        //[HttpDelete]
        //public async Task<ActionResult<ServiceResponse<List<GetCommissionDto>>>> Delete(int id)
        //{
            

        //    //BankTransfersContext db = new BankTransfersContext();
        //    //var commissions = _context.Commissions.FirstOrDefault(a => a.Id == id);
        //    //if (commissions != null)
        //    //{
        //    //    _context.Commissions.Remove(commissions);
        //    //    _context.SaveChanges();
        //    //    return "commissions Deleteed";
        //    //}
        //    //return "commissions not found";

        //}
    }

}
