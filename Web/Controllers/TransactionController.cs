using Domain.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.EntitiesServices.TransactionServices;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _service;

        public TransactionController(ITransactionService service)
        {
            _service = service;
        }

        [HttpGet("GetTransactions")]
        public async Task<List<TransactionDto>> GetTransactions()
        {
            return await _service.GetTransactions();
        }
        [HttpGet("GetTransactionById")]
        public async Task<TransactionDto> GetTransactionById(int id)
        {
            return await _service.GetTransactionById(id);
        }

        [HttpPost("Insert")]
        public async Task<int> Insert(TransactionDto dto)
        {
            return await _service.Insert(dto);
        }

        [HttpPost("Update")]
        public async Task<int> Update(TransactionDto dto)
        {
            return await _service.Update(dto);
        }
        [HttpPost("Delete")]
        public async Task<int> Delete(int id)
        {
            return await _service.Delete(id);
        }
    }
}
