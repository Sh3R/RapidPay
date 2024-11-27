using AutoMapper;
using MediatR;
using RapidPay.Application.Features.Add;
using RapidPay.Application.Repository.CardRepository;
using RapidPay.Application.Repository;
using RapidPay.Domain.Entities;

namespace RapidPay.Application.Features.Get
{
    public sealed class CardBalanceHandler : IRequestHandler<CardBalanceRequest, CardBalanceResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICardRepository _cardRepository;
        private readonly IMapper _mapper;
        public CardBalanceHandler(IUnitOfWork unitOfWork,
                   ICardRepository cardRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _cardRepository = cardRepository;
            _mapper = mapper;
        }
        public async Task<CardBalanceResponse> Handle(CardBalanceRequest request,
            CancellationToken cancellationToken)
        {
            var card = _mapper.Map<Card>(request);
            var result = await _cardRepository.GetByID(request.CardId, cancellationToken);

            return _mapper.Map<CardBalanceResponse>(result);
        }
    }
}