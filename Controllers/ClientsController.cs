using BankTransfers.DbModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankTransfers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly BankTransfersContext _context;
        private readonly IClientService _clientService;

        public ClientsController(BankTransfersContext context, IClientService clientService)
        {
            _context = context;
            _clientService = clientService;
        }

        [Route("GetAll")]
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetClientDto>>>> getall()
        {
            return await _clientService.GetAllClients();

        }

        [Route("Add")]
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetClientDto>>> Post(AddClientDto client)
        {
            return await _clientService.AddClient(client);
        }
        [Route("GetSingle")]
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<GetClientDto>>> getsingle(int id)
        {
            return await _clientService.GetClientById(id);

        }
    }
}










    

