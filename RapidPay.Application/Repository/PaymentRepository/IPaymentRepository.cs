using RapidPay.Domain.Entities;

namespace RapidPay.Application.Repository.PaymentRepository
{
    public interface IPaymentRepository : IBaseRepository<Transaction>
    {
        Task<Transaction> GetByID(Guid TransactionId, CancellationToken cancellationToken);
    }
}