using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public Decimal Balance { get; set; }
        public DateTime CreateDate { get; set; }
        public Status Status { get; set; }
        public Decimal Amount { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int WalletId { get; set; }
        public virtual Wallet Wallet { get; set; }

    }
    public enum Status
    {
        Successfully,
        Unsuccessfully
    }
}
