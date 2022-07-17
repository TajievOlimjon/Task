using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Models
{
    public  class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool Identified { get; set; }
        public string PhoneNumber { get; set; }
        public int UserDocumentId { get; set; }
    }
}
