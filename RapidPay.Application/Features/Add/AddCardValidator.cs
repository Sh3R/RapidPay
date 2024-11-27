using FluentValidation;

namespace RapidPay.Application.Features.Add
{
    public sealed class AddCardValidator : AbstractValidator<AddCardRequest>
    {
        public AddCardValidator()
        {
            RuleFor(x => x.CardNumber).CreditCard().MaximumLength(15);
            RuleFor(x => x.NameOnCard).NotEmpty().MinimumLength(2).MaximumLength(30);
            RuleFor(x => x.Balance).GreaterThanOrEqualTo(0);
        }
    }
}