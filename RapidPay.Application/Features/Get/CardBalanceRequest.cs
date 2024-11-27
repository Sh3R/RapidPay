using MediatR;

namespace RapidPay.Application.Features.Get
{
    public sealed record CardBalanceRequest(Guid CardId) : IRequest<CardBalanceResponse>;
}