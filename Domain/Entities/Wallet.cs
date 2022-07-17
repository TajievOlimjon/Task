using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Wallet
    {   
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreateDate { get; set; }
        public int UserId { get; set; }       
        public virtual User User { get; set; }

    }
}
