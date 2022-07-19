using AutoMapper;
using Domain.Entities;
using Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System.Linq;

namespace Services.EntitiesServices
{
    public class WalletService : IWalletService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public WalletService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


       public async Task<WalletSum> GetWalletBalanceByNumber(string PhoneNumber)
        {
                DateTime now = DateTime.UtcNow;
                var startDate = new DateTime( now.Month,(DateTimeKind)1);
                var endDate = startDate.AddMonths(1).AddDays(-1);

                var test = await (
                from t in _context.Wallets                 
                join m in _context.Users on t.UserId equals m.Id
                where m.PhoneNumber == PhoneNumber && t.CreateDate >= startDate && t.CreateDate <= endDate
                select new WalletSum
                {   UserId=m.Id,
                    Username=m.UserName,
                    Email=m.Email,
                    Phonenumber=m.PhoneNumber,
                    Count=_context.Wallets.Count(),
                    Sum=_context.Wallets.Sum(t=>t.Balance),
                   

                }).FirstOrDefaultAsync();          

            if (test == null) return new WalletSum();
            return test;
        }
        public async Task<WalletDto> GetWalletById(int Id)
        {

            var walet = await _context.Wallets
           .Where(w => w.Id == Id)
           .Select(w => new WalletDto { Balance = w.Balance }).FirstOrDefaultAsync();

            if (walet == null) return new WalletDto();
            return walet;


        }
        public async Task<WalletDto> GetWalletByNumberUser(string PhoneNumber)
        {
            var test = await(
                from t in _context.Wallets
                join m in _context.Users on t.UserId equals m.Id
                where m.PhoneNumber == PhoneNumber
                select new WalletDto
                {
                    Balance=t.Balance
                }).FirstOrDefaultAsync();

            if (test == null) return new WalletDto();
            return test;
        }

        public async Task<List<WalletDto>> GetWallets()
        {


            var wallets = await _context.Wallets
                .Select(w => new WalletDto
                {
                    Id = w.Id,
                    Balance = w.Balance,
                    CreateDate = w.CreateDate,
                    UserId = w.UserId

                }).ToListAsync();


            return wallets;
        }

        public async Task<int> Insert(WalletDto wallet)
        {
            var mapped = _mapper.Map<Wallet>(wallet);
            await _context.Wallets.AddAsync(mapped);
            return await _context.SaveChangesAsync();
        }

       
    }
}
