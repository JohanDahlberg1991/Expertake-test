namespace Data.Models
{
    public class LatencyResult
    {
        public List<LatencyDataItem> AverageLatancies { get; set; }

        public List<string> Period { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        private LatencyResult()
        {

        }

        internal static LatencyResult Create(List<LatencyDataItem> averageLatancies, DateTime startDate, DateTime endDate)
        {
            return new LatencyResult
            {
                AverageLatancies = averageLatancies,
                StartDate = startDate,
                EndDate = endDate,
                Period = new List<string> { startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd") }
            };
        }
    }
}
