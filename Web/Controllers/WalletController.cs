using Domain.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.EntitiesServices;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalletController:ControllerBase
    {
        private readonly IWalletService _walletService;

        public WalletController(IWalletService walletService )
        {
              _walletService = walletService;
        }

        [HttpGet("GetWalletById")]
        public async Task<WalletDto> GetWalletById(int Id)
        {
            return await _walletService.GetWalletById(Id);
        }
        [HttpGet("GetWalletCountById")]
        public async Task<WalletDto> GetWalletCountById(string phone)
        {
            return await _walletService.GetWalletCountById(phone);
        }

        [HttpGet("GetBalanceByNumberUser")]
        public async Task<WalletDto> GetWalletByNumberUser(string PhoneNumber)
        {
            return await _walletService.GetWalletByNumberUser(PhoneNumber);
        }
        [HttpGet("GetWallets")]
        public async Task<List<WalletDto>> GetWalletsAsync()
        {
            return await _walletService.GetWallets();
        }

        [HttpPost("AddWaleet")]
        public async Task<int> Insert(WalletDto wallet)
        {
            return await _walletService.Insert(wallet);
        }
    }
}
