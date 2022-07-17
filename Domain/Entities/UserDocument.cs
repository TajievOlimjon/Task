using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserDocument
    {
        public Guid Id { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string PassportNumber { get; set; }
        public string INN { get; set; }

    }
}
