using RapidPay.Application.Features.Payment;
using RapidPay.Domain.Entities;
using RapidPay.Domain.Models;
using System.Transactions;

namespace RapidPay.Application.Services.Payment
{
    public interface IPaymentService
    {
        Task<ProcessResult> ProcessPayment(Card card, PaymentRequest reqest, CancellationToken cancellationToken);
    }
}
