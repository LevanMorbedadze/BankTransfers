using BankTransfers.Dto.CommissionDto;

namespace BankTransfers.Services.CommissionService
{
    public class CommissionService : ICommissionService
    {
        private readonly BankTransfersContext _context;
        private readonly IMapper _mapper;

        public CommissionService(BankTransfersContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<GetCommissionDto>> AddCommision(AddCommissionDto newCommission)
        {
            var dbCommission = _mapper.Map<Commission>(newCommission);
            _context.Commissions.Add(dbCommission);
            _context.SaveChanges();
            var getCommissionDto = _mapper.Map<GetCommissionDto>(dbCommission);
            var serviceresponse = new ServiceResponse<GetCommissionDto>();
            serviceresponse.Date = getCommissionDto;
            return serviceresponse;
        }       
        public async Task<ServiceResponse<List<GetCommissionDto>>> GetAllCommission()
        {
            var response = new ServiceResponse<List<GetCommissionDto>>();
            var dbCommission = await _context.Commissions.ToListAsync();
            var getCommissionDto = dbCommission.Select(x => _mapper.Map<GetCommissionDto>(x)).ToList();
            response.Date = getCommissionDto;
            return response;
        }

        public async Task<ServiceResponse<GetCommissionDto>> GetCommissionById(int id)
        {
            var response = new ServiceResponse<GetCommissionDto>();
            var dbCommission = await _context.Commissions.FirstOrDefaultAsync(x => x.Id == id);
            if (dbCommission == null)
            {
                response.success = false;
                response.Message = "commission not found";
                throw new Exception("commission not found");
            }
            var getCommissionDto = _mapper.Map<GetCommissionDto>(dbCommission);
            response.Date = getCommissionDto;
            return response;
        }

        public async Task<ServiceResponse<GetCommissionDto>> UpdateCommision(UpdateCommissionDto newCommission)
        {
            var response = new ServiceResponse<GetCommissionDto>();
            var dbCommission = await _context.Commissions.FirstOrDefaultAsync(x => x.Id == newCommission.Id);
            if (dbCommission == null)
            {
                response.success = false;
                response.Message = "commission not found";
                throw new Exception("commission not found");
            }
            dbCommission.TransferFee = dbCommission.TransferFee;
            dbCommission.CommissionIncome = dbCommission.CommissionIncome;


            var getCommissionDto = _mapper.Map<GetCommissionDto>(dbCommission);
            await _context.SaveChangesAsync();
            response.Date = getCommissionDto;
            return response;
        }

       
    }
}
