using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Services.EntitiesServices.UserDocumentService
{
    public  class UserDocumentService:IUserDocumentService
    {
        private readonly DataContext _context;

        public UserDocumentService(DataContext context)
        {
            _context = context;
        }

        public async Task<int> Delete(int id)
        {
            var userDoc= await _context.UserDocuments.FindAsync(id);
            if (userDoc == null) return 0;
            _context.UserDocuments.Remove(userDoc);
            return await _context.SaveChangesAsync();
        }

        public async Task<UserDocument> GetUserDocumentById(int id)
        {
            return await _context.UserDocuments.FindAsync(id);
        }

        public async Task<List<UserDocument>> GetUserDocuments()
        {
            return await _context.UserDocuments.ToListAsync();
        }

        public async Task<int> Insert(UserDocument document)
        {
            await _context.UserDocuments.AddAsync(document);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(UserDocument document)
        {
            var userDos = await _context.UserDocuments.FindAsync(document.Id);
            if (userDos == null) return 0;
            userDos.Gender = document.Gender;
            userDos.BirthDate = document.BirthDate;
            userDos.PassportNumber=document.PassportNumber;
            userDos.INN = document.INN;
            return await _context.SaveChangesAsync();
        }
    }
}
