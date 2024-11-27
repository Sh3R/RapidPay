using Microsoft.VisualBasic;
using RapidPay.Application.Features.Payment;
using RapidPay.Application.Repository;
using RapidPay.Application.Repository.CardRepository;
using RapidPay.Application.Repository.PaymentRepository;
using RapidPay.Application.Services.Fee;
using RapidPay.Domain.Entities;
using RapidPay.Domain.Models;
using System.Transactions;

namespace RapidPay.Application.Services.Payment
{
    public class PaymentService : IPaymentService
    {
        private readonly IFeeService _feeService;
        private readonly IPaymentRepository _paymentRepository;
        private readonly ICardRepository _cardRepository;
        private readonly IUnitOfWork _unitOfWork;
        private static readonly SemaphoreSlim Semaphore = new(1);
        /// <summary>
        /// There all functions for Payment service will be added
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="feeService"></param>
        /// <param name="paymentRepository"></param>
        /// <param name="cardRepository"></param>
        public PaymentService(IUnitOfWork unitOfWork, IFeeService feeService, IPaymentRepository paymentRepository, ICardRepository cardRepository)
        {
            _feeService = feeService;
            _paymentRepository = paymentRepository;
            _unitOfWork = unitOfWork;
            _cardRepository = cardRepository;
        }
        /// <summary>
        /// main feature to process the payment and update proper database tables
        /// </summary>
        /// <param name="card"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ProcessResult> ProcessPayment(Card card, PaymentRequest request, CancellationToken cancellationToken)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    //useing semaphore in order to reach thread safety
                    await Semaphore.WaitAsync();
                    var processResult = new ProcessResult();
                    var currentFee = await _feeService.GetCurrentFee();
                    //firstly create transaction and save as not completed one
                    var transaction = new Domain.Entities.Transaction
                    {
                        Card = card,
                        Payment = request.Amount,
                        Fee = currentFee,
                        CardId = card.Id
                    };
                    //all save operations to DB
                    _paymentRepository.Create(transaction);
                    await _unitOfWork.Save(cancellationToken);

                    //performing calculations of new balance
                    var newBalance = card.Balance - transaction.Payment - currentFee;
                    //check if user has funds for the payment
                    if (newBalance < 0)
                    {
                        processResult.TransactionId = transaction.Id;
                        return processResult;
                    }
                    //update proper data to DB
                    card.Balance = newBalance;
                    transaction.IsSuccess = true;
                    _cardRepository.Update(card);
                    _paymentRepository.Update(transaction);
                    await _unitOfWork.Save(cancellationToken);
                    scope.Complete();
                    //prepare return data
                    processResult.IsSuccess = true;
                    processResult.TransactionId = transaction.Id;
                    return processResult;
                }
                catch (Exception e)
                {
                    scope.Dispose();
                    return new ProcessResult() { IsSuccess = false };
                }
                finally
                {
                    Semaphore.Release();
                }
            }
        }
    }
}