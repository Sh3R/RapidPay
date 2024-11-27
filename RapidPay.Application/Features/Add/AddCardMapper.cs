using AutoMapper;
using RapidPay.Domain.Entities;

namespace RapidPay.Application.Features.Add
{
    public sealed class AddCardMapper : Profile
    {
        public AddCardMapper()
        {
            CreateMap<AddCardRequest, Card>();
            CreateMap<Card, AddCardResponse>();
        }
    }
}