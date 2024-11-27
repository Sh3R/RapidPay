using RapidPay.Domain.Entities;

namespace RapidPay.Application.Repository.CardRepository
{
    public interface ICardRepository : IBaseRepository<Card>
    {
        Task<Card> GetByID(Guid CardId, CancellationToken cancellationToken);
        Task<Card> CheckCardStatusById(Guid CardId, CancellationToken cancellationToken);
    }
}