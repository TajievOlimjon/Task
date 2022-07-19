using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Models
{
    public class WalletDto
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public string UserId { get; set; }
    }

    public class WalletSum
    {   public string? UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
        public decimal Count { get; set; }
        public decimal Sum { get; set; }

    }
}
