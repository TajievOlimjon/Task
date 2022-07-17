using AutoMapper;
using Domain.Entities;
using Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Services.EntitiesServices.UserServices
{
    public  class UserService:IUserService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserService(DataContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Delete(int id)
        {
            var user= await _context.Users.FindAsync(id);
            if(user==null) return 0;
            _context.Users.Remove(user);
            return await _context.SaveChangesAsync();
        }

        public async Task<UserDto> GetUserById(int id)
        {
            var user = await (from u in _context.Users
                              where u.Id==id
                              select new UserDto
                              {
                                  Id=u.Id,
                                  UserName=u.UserName,
                                  Email=u.Email,
                                  Identified=u.Identified,
                                  PhoneNumber=u.PhoneNumber,
                                  UserDocumentId=u.UserDocumentId,
                                  

                              }).FirstOrDefaultAsync();
            if (user == null) return new UserDto();
            return user;
        }

        public async Task<List<UserDto>> GetUsers()
        {
           return   await( from u in _context.Users
                             select new UserDto
                             {
                                 Id = u.Id,
                                 UserName = u.UserName,
                                 Email = u.Email,
                                 Identified = u.Identified,
                                 PhoneNumber = u.PhoneNumber,
                                 UserDocumentId = u.UserDocumentId,

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
            user.UserDocumentId = userDto.UserDocumentId;
            return await _context.SaveChangesAsync();
        }
    }
}
