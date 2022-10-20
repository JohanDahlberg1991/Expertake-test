using Data.Models;
using Data.Service.Interface;
using System.Net.Http.Headers;

namespace Data.Service
{
    public class LatencyService: ILatencyService
    {

        public LatencyService()
        {

        }
        public async Task<LatencyResult> GetLatencyResult(DateTime startDate, DateTime endDate)
        {
            var requestItems = new List<LatencyRequestItem>();
            var averageLantacies = new List<LatencyDataItem>();


            //TODO check if dates are not null/empty and if startDate is before endDate
            List<DateTime> allDates = new List<DateTime>();

            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
                allDates.Add(date);      

            foreach (DateTime date in allDates)
            {
                var distinctDataObjects = GetLantencyDataForDate(date).GroupBy(p => p.RequestId).Select(g => g.First()).ToList();
                requestItems.AddRange(distinctDataObjects);
            }    

            foreach (var serviceId in requestItems.Select(ri => ri.ServiceId).Distinct().ToList())
            {
                var allItemsForServiceId = requestItems.Where(ri => ri.ServiceId == serviceId).ToList();
                var item = LatencyDataItem.Create(serviceId, allItemsForServiceId.Count(), allItemsForServiceId.Select(ri => ri.MilliSecondsDelay).Average());
                averageLantacies.Add(item);
            }

            //TODO have a defaultServiceResult with error code for different scenarios
            return LatencyResult.Create(averageLantacies, startDate, endDate);
        }

        const string url = "http://latencyapi-env.eba-kqb2ph3i.eu-west-1.elasticbeanstalk.com/latencies";
        private IEnumerable<LatencyRequestItem> GetLantencyDataForDate(DateTime date)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync($"?date={date.ToString("yyyy-MM-dd")}").Result;
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                var dataObjects = response.Content.ReadFromJsonAsync<IEnumerable<LatencyRequestItem>>().Result;
                client.Dispose();
                return dataObjects.ToList();
            }
            else
            {
                client.Dispose();
                return new List<LatencyRequestItem>();
            }
        }
    }
}
