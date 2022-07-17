using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Models
{
    public  class TransactionDto
    {
        public int Id { get; set; }
        public Decimal Balance { get; set; }
        public DateTime CreateDate { get; set; }
        public Status Status { get; set; }
        public Decimal Amount { get; set; }
        public int UserId { get; set; }
        public int WalletId { get; set; }
    }
}
