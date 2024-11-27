using Microsoft.EntityFrameworkCore;
using RapidPay.Application.Repository.CardRepository;
using RapidPay.Application.Repository.PaymentRepository;
using RapidPay.Domain.Entities;
using RapidPay.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.Infrastructure.Repository.PaymntRepository
{
    public class PaymentRepository : BaseRepository<Transaction>, IPaymentRepository
    {
        public PaymentRepository(DBContext context) : base(context)
        {
        }
        public async Task<Transaction> GetByID(Guid TransactionId, CancellationToken cancellationToken)
        {
            return await Context.Transactions.FirstOrDefaultAsync(x => x.Id == TransactionId, cancellationToken);
        }
    }
}
