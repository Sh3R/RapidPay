using Microsoft.EntityFrameworkCore;
using RapidPay.Application.Repository.CardRepository;
using RapidPay.Domain.Entities;
using RapidPay.Infrastructure.Context;

namespace RapidPay.Infrastructure.Repository.CardRepository
{
    public class CardRepository : BaseRepository<Card>, ICardRepository
    {
        public CardRepository(DBContext context) : base(context)
        {
        }

        public async Task<Card> CheckCardStatusById(Guid CardId, CancellationToken cancellationToken)
        {
            var isActiveCard = await Context.Cards.FirstOrDefaultAsync(e => e.Id == CardId && !e.IsDeleted, cancellationToken: cancellationToken);
            return isActiveCard;
        }

        public async Task<Card> GetByID(Guid CardId, CancellationToken cancellationToken)
        {
            return await Context.Cards.FirstOrDefaultAsync(x => x.Id == CardId, cancellationToken);
        }
    }
}