namespace Data.Models
{
    public class LatencyDataItem
    {
        public int ServiceId { get; set; }
        public int NumberOfRequests { get; set; }
        public double AverageResponseTimeMs { get; set; }

        private LatencyDataItem()
        {

        }

        internal static LatencyDataItem Create(int serviceId, int numberOfRequests, double averageResponseTime)
        {
            return new LatencyDataItem
            {
                ServiceId = serviceId,
                NumberOfRequests = numberOfRequests,
                AverageResponseTimeMs = averageResponseTime
            };
        }
    }
}
