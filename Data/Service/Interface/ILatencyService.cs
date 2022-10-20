using Data.Models;

namespace Data.Service.Interface
{
    public interface ILatencyService
    {
        Task<LatencyResult> GetLatencyResult(DateTime startDate, DateTime endDate);
    }
}
