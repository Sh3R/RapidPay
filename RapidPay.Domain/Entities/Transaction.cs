using RapidPay.Domain.Common;

namespace RapidPay.Domain.Entities
{
    public class Transaction : BaseEntity
    {
        public Transaction()
        {
            Card = new Card();
        }
        public Guid CardId { get; set; }
        public decimal Payment { get; set; }
        public decimal Fee { get; set; }
        public bool IsSuccess { get; set; }
        public Card Card { get; set; }
    }
}