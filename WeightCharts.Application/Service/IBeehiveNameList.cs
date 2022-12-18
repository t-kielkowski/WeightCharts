namespace WeightCharts.Application.Service
{
    public interface IBeehiveNameList
    {
        Task<IEnumerable<string>> GetBeehiveNameListAsync();
    }
}
