namespace Data.Models
{
    public class LatencyRequestItem
    {
        public int RequestId { get; set; }
        public int ServiceId { get; set; }
        public DateTime Date { get; set; }
        public int MilliSecondsDelay { get; set; }
    }
}
