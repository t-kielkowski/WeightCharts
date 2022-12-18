namespace WeightCharts.Application.ApiAccess
{
    public interface IWeightReadingsSearchParams
    {
        string WeightId { get; set; }
        DateTime? DateFrom { get; set; }
        DateTime? DateTo { get; set; }
    }
}
