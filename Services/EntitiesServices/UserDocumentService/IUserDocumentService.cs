using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.EntitiesServices.UserDocumentService
{
    public  interface IUserDocumentService
    {
        Task<List<UserDocument>> GetUserDocuments();
        Task<UserDocument> GetUserDocumentById(int id);
        Task<int> Insert(UserDocument document);
        Task<int> Update(UserDocument document);
        Task<int> Delete(int id);   
    }
}
