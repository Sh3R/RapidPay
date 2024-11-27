using MediatR;
using RapidPay.Application.Features.Add;

namespace RapidPay.Application.Features.Payment
{
    public sealed record PaymentRequest(Guid CardId, decimal Amount) : IRequest<PaymentResponse>;
}
