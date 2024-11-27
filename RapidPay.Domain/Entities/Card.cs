using RapidPay.Domain.Common;

namespace RapidPay.Domain.Entities
{
    public class Card : BaseEntity
    {
        public Card() => Transactions = [];
        public string CardNumber { get; set; }
        public decimal Balance { get; set; }
        public string NameOnCard { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}