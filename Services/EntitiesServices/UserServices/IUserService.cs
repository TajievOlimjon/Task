using Domain.Entities;
using Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.EntitiesServices.UserServices
{
    public  interface IUserService
    {
        Task<List<UserDto>> GetUsers();
        Task<UserDto> GetUserById(int id);
        Task<int> Insert(UserDto userDto);
        Task<int> Update(UserDto userDto);
        Task<int> Delete(string id);

    }
}
