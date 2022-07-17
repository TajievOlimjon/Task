using Domain.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.EntitiesServices.UserServices;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        //[HttpGet("GetList_Of_Authorized_Users")]
        //public async Task<List<UserDto>> GetUsers()
        //{
        //    return await _userService.GetUsers();


        //}

        //[HttpGet("GetUserById")]
        //public async Task<UserDto> GetUserById(int id)
        //{
        //    return await _userService.GetUserById(id);
        //}

        ////[HttpPost("Insert")]
        ////public async Task<int> Insert(UserDto dto)
        ////{
        ////    return await _userService.Insert(dto);
        ////}

        //[HttpPut("Update")]
        //public async Task<int> Update(UserDto dto)
        //{
        //    return await _userService.Update(dto);
        //}

        //[HttpDelete("Delete")]
        //public async Task<int> Delete(int id)
        //{
        //    return await _userService.Delete(id);
        //}

    }
}
