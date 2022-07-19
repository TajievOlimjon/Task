using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data
{
    public  class DataContext:IdentityDbContext<User> 
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

       // public DbSet<User> Users { get; set; }
        public DbSet<Wallet> Wallets{ get; set; }
        public DbSet<Transaction> Transactions { get; set; }


    }
}
