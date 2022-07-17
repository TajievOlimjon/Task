using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Services.EntitiesServices.UserDocumentService;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserDocumentController:ControllerBase
    {
        private readonly IUserDocumentService _documentService;

        public UserDocumentController(IUserDocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpGet("GetUser_Documents")]
        public async Task<List<UserDocument>> UserDocuments()
        {
            return await _documentService.GetUserDocuments();
        }

        [HttpGet("GetUser_DocumentById")]
        public async Task<UserDocument> UserDocumentById(int id)
        {
            return await _documentService.GetUserDocumentById(id);
        }

        [HttpPost("Insert")]
        public async Task<int> Insert(UserDocument document)
        {
            return await _documentService.Insert(document);
        }

        [HttpPut("Update")]
        public async Task<int> Update(UserDocument document)
        {
            return await _documentService.Update(document);
        }

        [HttpDelete("Delete")]
        public async Task<int> Delete(int id)
        {
            return await _documentService.Delete(id);
        }
    }
}
