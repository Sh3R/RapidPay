using AutoMapper;
using RapidPay.Domain.Entities;

namespace RapidPay.Application.Features.Get
{
    public sealed class CardBalanceMapper : Profile
    {
        public CardBalanceMapper()
        {
            CreateMap<CardBalanceRequest, Card>();
            CreateMap<Card, CardBalanceResponse>();
        }
    }
}