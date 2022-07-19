using AutoMapper;
using Domain.Entities;
using Domain.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Services.EntitiesServices.UserServices
{
    public  class UserService:IUserService
    {
        private readonly DataContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public UserService(IMapper mapper, DataContext context, UserManager<User> userManager)
        {
            _context = context;
           _userManager = userManager;
            _mapper = mapper;
            
        }

        public async Task<int> Delete(string id)
        {
            var user= await _context.Users.FirstOrDefaultAsync(user=>user.Id==id);
            if(user==null) return 0;
            _context.Users.Remove(user);
            return await _context.SaveChangesAsync();
        }

        public async Task<UserDto> GetUserById(int id)
        {
            var user = await (from u in _context.Users
                           //   where u.Id==id
                              select new UserDto
                              {
                                 // Id=u.Id,
                                  UserName=u.UserName,
                                  Email=u.Email,
                                  Identified=u.Identified,
                                  PhoneNumber=u.PhoneNumber
                                  

                              }).FirstOrDefaultAsync();
            if (user == null) return new UserDto();
            return user;
        }

        public async Task<List<UserDto>> GetUsers()
        {
           return   await( from u in _context.Users
                             select new UserDto
                             {
                                 //Id = u.Id,
                                 UserName = u.UserName,
                                 Email = u.Email,
                                 Identified = u.Identified,
                                 PhoneNumber = u.PhoneNumber

                             }).ToListAsync();
            
        }

        public async Task<int> Insert(UserDto userDto)
        {
            var mapped = _mapper.Map<User>(userDto);
            await _context.Users.AddAsync(mapped);
            return await _context.SaveChangesAsync();
        }

        public async  Task<int> Update(UserDto userDto)
        {
            var user = await _context.Users.FindAsync(userDto.Id);
            if (user == null) return 0;
            user.UserName = userDto.UserName;
            user.Email = userDto.Email;
            user.Identified = userDto.Identified;
            user.PhoneNumber = userDto.PhoneNumber;
            return await _context.SaveChangesAsync();
        }
    }
}
