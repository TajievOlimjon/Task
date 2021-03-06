using Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.EntitiesServices
{
    public  interface IWalletService
    {
        Task<List<WalletDto>> GetWallets();
        Task<WalletSum> GetWalletBalanceByNumber(string PhoneNumber);
        Task<WalletDto> GetWalletByNumberUser(string PhoneNumber);
        Task<WalletDto> GetWalletById(int Id);
        Task<int> Insert(WalletDto wallet);
    }
}
