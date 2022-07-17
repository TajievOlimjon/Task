using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User: IdentityUser
    {
        public int Id { get; set; }      
        public bool Identified { get; set; }
        public int UserDocumentId { get; set; }
        public virtual UserDocument UserDocument { get; set; }

    }
}
