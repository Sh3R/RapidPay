using MediatR;

namespace RapidPay.Application.Features.Add
{
    public sealed record AddCardRequest(string CardNumber, double Balance, string NameOnCard) : IRequest<AddCardResponse>;
}