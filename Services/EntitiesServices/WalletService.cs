using AutoMapper;
using Domain.Entities;
using Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

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

        public async Task<WalletDto> GetWalletCountById(string PhoneNumber)
        {
            DateTime now = DateTime.UtcNow;
            var startDate = new DateTime(now.Year, now.Month,1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            var walet = await _context.Wallets
                               .Where(w=> w.User.PhoneNumber == PhoneNumber)
                               .Where(w=> w.CreateDate >= startDate && w.CreateDate <= endDate)
                               .Select(w=> new WalletDto
                               {
                                   Id = w.ToString().Count()


                               }).FirstOrDefaultAsync();

            if (walet == null) return new WalletDto();
            return walet;
        }
        public async Task<WalletDto> GetWalletById(int Id)
        {

            var walet = await _context.Wallets
           .Where(w => w.Id == Id)
           .Select(w => new WalletDto { Balance = w.Balance }).FirstOrDefaultAsync();

            if (walet == null) return new WalletDto();
            return walet;
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
