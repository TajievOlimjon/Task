using Domain.AccountDto;
using Domain.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.AccountServices;
using Services.EntitiesServices.UserServices;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;
        private readonly IUserService _userService;

        public AccountController(AccountService accountService, IUserService userService)
        {
            _accountService = accountService;
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterDto register)
        {
            if (!ModelState.IsValid) { return BadRequest(register); }
            var user = await _accountService.Register(register);
            return Ok(user);
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(Login login)
        {
            if (!ModelState.IsValid) { return BadRequest(login); }
            var user= await _accountService.Login(login);
            return Ok(user);

        }
       

        [HttpGet("GetList_Of_Authorized_Users")]
        public async Task<List<UserDto>> GetUsers()
        {
            return await _userService.GetUsers();


        }

        [HttpGet("GetUserById")]
        public async Task<UserDto> GetUserById(int id)
        {
            return await _userService.GetUserById(id);
        }

        [HttpPut("Update")]
        public async Task<int> Update(UserDto dto)
        {
            return await _userService.Update(dto);
        }

        [HttpDelete("Delete")]
        public async Task<int> Delete(int id)
        {
            return await _userService.Delete(id);
        }
    }
}
