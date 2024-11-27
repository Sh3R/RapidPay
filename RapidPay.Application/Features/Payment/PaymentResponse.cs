namespace RapidPay.Application.Features.Payment
{
    public sealed record class PaymentResponse
    {
        public Guid? ID { get; set; }
        public bool IsSuccess { get; set; }
    }
}