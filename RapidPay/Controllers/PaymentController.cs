using MediatR;
using Microsoft.AspNetCore.Mvc;
using RapidPay.API.Controllers.Base;
using RapidPay.Application.Features.Add;
using RapidPay.Application.Features.Payment;

namespace RapidPay.API.Controllers
{
    public class PaymentController : BaseController
    {
        private readonly IMediator _mediator;
        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<PaymentResponse>> Pay(PaymentRequest request,
            CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
