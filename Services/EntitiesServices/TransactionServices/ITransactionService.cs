using Domain.Entities.Models;

namespace Services.EntitiesServices.TransactionServices
{
    public  interface ITransactionService
    {
        Task<List<TransactionDto>> GetTransactions();
        Task<TransactionDto> GetTransactionById(int id);
        Task<int> Insert(TransactionDto dto);
        Task<int> Update(TransactionDto dto);
        Task<int> Delete(int id);

    }
}
