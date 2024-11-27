using AutoMapper;
using RapidPay.Application.Repository.CardRepository;
using RapidPay.Application.Repository;
using MediatR;
using RapidPay.Application.Services.Payment;

namespace RapidPay.Application.Features.Payment
{
    public class PaymentHandler : IRequestHandler<PaymentRequest, PaymentResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICardRepository _cardRepository;
        private readonly IMapper _mapper;
        private readonly IPaymentService _paymentService;
        /// <summary>
        /// handler for Payment request
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="cardRepository"></param>
        /// <param name="mapper"></param>
        /// <param name="paymentService"></param>
        public PaymentHandler(IUnitOfWork unitOfWork,
                  ICardRepository cardRepository, IMapper mapper, IPaymentService paymentService)
        {
            _unitOfWork = unitOfWork;
            _cardRepository = cardRepository;
            _mapper = mapper;
            _paymentService = paymentService;
        }
        public async Task<PaymentResponse> Handle(PaymentRequest request,
            CancellationToken cancellationToken)
        {
            //check if card is active before moving to transaction
            var card = await _cardRepository.CheckCardStatusById(request.CardId, cancellationToken);
            if (card == null)
            {
                return _mapper.Map<PaymentResponse>(new PaymentResponse { IsSuccess = false });
            }
            //send payment to processing
            var paymentResult = await _paymentService.ProcessPayment(card, request, cancellationToken);
            return _mapper.Map<PaymentResponse>(paymentResult);
        }
    }
}