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
}
