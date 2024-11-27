using AutoMapper;
using MediatR;
using RapidPay.Application.Repository;
using RapidPay.Application.Repository.CardRepository;
using RapidPay.Domain.Entities;

namespace RapidPay.Application.Features.Add
{
    public sealed class AddCardHandler : IRequestHandler<AddCardRequest, AddCardResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICardRepository _cardRepository;
        private readonly IMapper _mapper;
        public AddCardHandler(IUnitOfWork unitOfWork,
                   ICardRepository cardRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _cardRepository = cardRepository;
            _mapper = mapper;
        }

        public async Task<AddCardResponse> Handle(AddCardRequest request,
            CancellationToken cancellationToken)
        {
            var card = _mapper.Map<Card>(request);
            _cardRepository.Create(card);
            await _unitOfWork.Save(cancellationToken);

            return _mapper.Map<AddCardResponse>(card);
        }
    }
}