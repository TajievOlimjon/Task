using AutoMapper;
using Domain.Entities;
using Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;


namespace Services.EntitiesServices.TransactionServices
{
    public  class TransactionService:ITransactionService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public TransactionService(DataContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Delete(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null) return 0;
            _context.Transactions.Remove(transaction);
            return await _context.SaveChangesAsync();
        }

        public async Task<TransactionDto> GetTransactionById(int id)
        {
            var transaction = await (from t in _context.Transactions
                                     where t.Id==id
                                     select new TransactionDto
                                     {
                                         Id=t.Id,
                                         Balance=t.Balance,
                                         CreateDate=t.CreateDate,
                                         Status=t.Status,
                                         Amount=t.Amount,
                                         UserId=t.UserId,
                                         WalletId=t.WalletId

                                     }).FirstOrDefaultAsync();
            if (transaction == null) return new TransactionDto();
            return transaction;
        }

        public async Task<List<TransactionDto>> GetTransactions()
        {
            var transaction = await _context.Transactions
                                    .Select(t=> new TransactionDto
                                    {
                                        Id = t.Id,
                                        Balance = t.Balance,
                                        CreateDate = t.CreateDate,
                                        Status = t.Status,
                                        Amount = t.Amount,
                                        UserId = t.UserId,
                                        WalletId = t.WalletId

                                    }).ToListAsync();
            return transaction;
        }

        public async Task<int> Insert(TransactionDto dto)
        {
            var mapped = _mapper.Map<Transaction>(dto);
            await _context.Transactions.AddAsync(mapped);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(TransactionDto dto)
        {
            var transaction = await _context.Transactions.FindAsync(dto.Id);
            if (transaction == null) return 0;

            transaction.Balance = dto.Balance;
            transaction.CreateDate = dto.CreateDate;
            transaction.Status = dto.Status;
            transaction.Amount = dto.Amount;
            transaction.UserId = dto.UserId;
            transaction.WalletId = dto.WalletId;
            return await _context.SaveChangesAsync();
        }
    }
}
