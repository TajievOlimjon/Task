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
        public DateTime CreateDate { get; set; }
        public int UserId { get; set; }
    }
}
