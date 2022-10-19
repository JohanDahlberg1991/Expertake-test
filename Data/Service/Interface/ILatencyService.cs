using Data.Models;

namespace Data.Service.Interface
{
    public interface ILatencyService
    {
        Task<LatencyResult> GetLatencyTestResult(DateTime startDate, DateTime endDate);
    }
}
