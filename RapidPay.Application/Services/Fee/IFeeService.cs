namespace RapidPay.Application.Services.Fee
{
    public interface IFeeService
    {
        Task<decimal> GetCurrentFee();
    }
}