using BankTransfers.Dto;
using BankTransfers.Dto.AccountDto;


namespace BankTransfers.Services.ClientService
{
    public class ClientService : IClientService
    {
        private readonly BankTransfersContext _context;
        private readonly IMapper _mapper;

        public ClientService(BankTransfersContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<GetClientDto>> AddClient(AddClientDto newClient)
        {
            var dbClient = _mapper.Map<Client>(newClient);
            _context.Clients.Add(dbClient);
            _context.SaveChanges();
            var getClientDto = _mapper.Map<GetClientDto>(dbClient);
            var serviceresponse = new ServiceResponse<GetClientDto>();
            serviceresponse.Date = getClientDto;
            return serviceresponse;

        }        

        public async Task<ServiceResponse<List<GetClientDto>>> GetAllClients()
        {
            var response = new ServiceResponse<List<GetClientDto>>();
            var dbClient = await _context.Clients.ToListAsync();
            var getClientDto = dbClient.Select(x => _mapper.Map<GetClientDto>(x)).ToList();
            response.Date = getClientDto;
            return response;
        }

        public async Task<ServiceResponse<GetClientDto>> GetClientById(int id)
        {
            var response = new ServiceResponse<GetClientDto>();
            var dbClient = await _context.Clients.FirstOrDefaultAsync(x => x.Id == id);
            if (dbClient == null)
            {
                response.success = false;
                response.Message = "client not found";
                throw new Exception("client not found");
            }
            var getClientDto = _mapper.Map<GetClientDto>(dbClient);
            response.Date = getClientDto;
            return response;
        }

       
    }
}



