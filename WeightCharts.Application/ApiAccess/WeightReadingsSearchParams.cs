namespace WeightCharts.Application.ApiAccess
{
    public class WeightReadingsSearchParams : IWeightReadingsSearchParams
    {
        public string WeightId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
