using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
      
        public bool Identified { get; set; }
        public string PhoneNumber { get; set; }
        public Guid UserDocument { get; set; }
        public virtual UserDocument UserDocuments { get; set; }

    }
}
