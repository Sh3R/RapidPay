using MediatR;
using Microsoft.AspNetCore.Mvc;
using RapidPay.Application.Features;
using RapidPay.API.Controllers.Base;
using RapidPay.Application.Features.Add;
using RapidPay.Application.Features.Get;
using System.Web.Mvc;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using AuthorizeAttribute = RapidPay.Infrastructure.Attributes.AuthorizeAttribute;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace RapidPay.API.Controllers
{
    [Authorize]
    public class CardController : BaseController
    {
        private readonly IMediator _mediator;
        public CardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<AddCardResponse>> Create(AddCardRequest request,
            CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<CardBalanceResponse>> GetCardBalance(CardBalanceRequest request,
            CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
