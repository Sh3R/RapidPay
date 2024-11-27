
namespace RapidPay.Application.Services.Fee
{
    public class FeeService : IFeeService
    {
        private static readonly Lazy<FeeService> _instance = new(() => new FeeService());
        private readonly Random _random = new();
        private decimal _currentFee;
        public FeeService()
        {
            _currentFee = 1; // Initial fee rate.
            StartFeeUpdate();
        }
        public Task<decimal> GetCurrentFee()
        {
            return Task.FromResult(decimal.Round(_currentFee, 2, MidpointRounding.AwayFromZero));
        }
        public static FeeService Instance => _instance.Value;
        private void StartFeeUpdate()
        {
            var timer = new System.Timers.Timer(3600000); // 1 hour in milliseconds 3600000
            timer.Elapsed += (sender, args) => _currentFee *= (decimal)(_random.NextDouble() * 2);
            timer.Start();
        }
    }
}