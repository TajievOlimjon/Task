namespace Domain.Entities
{
    public class Wallet
    {   
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public string UserId { get; set; }       
        public virtual User? User { get; set; }

    }
}
