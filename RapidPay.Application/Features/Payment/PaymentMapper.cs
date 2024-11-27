using AutoMapper;
using RapidPay.Domain.Entities;
using RapidPay.Domain.Models;

namespace RapidPay.Application.Features.Payment
{
    public class PaymentMapper : Profile
    {
        public PaymentMapper()
        {
            CreateMap<PaymentRequest, Transaction>().ForMember(e => e.Payment, m => m.MapFrom(u => u.Amount));
            CreateMap<Transaction, PaymentResponse>();
            CreateMap<ProcessResult, PaymentResponse>().ForMember(e => e.ID, m => m.MapFrom(u => u.TransactionId));
        }
    }
}