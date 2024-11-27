using FluentValidation;

namespace RapidPay.Application.Features.Payment
{
    public class PaymentValidator : AbstractValidator<PaymentRequest>
    {
        public PaymentValidator()
        {
            RuleFor(x => x.Amount).GreaterThan(0);
            RuleFor(x => x.CardId).NotEmpty();
        }
    }
}