using WeightChart.Infrastructure.DbModel;

namespace WeightChart.Infrastructure.Repository
{
    public class BH1750Repository : BaseRepository<Bh1750>, IBH1750Repository
    {
        public BH1750Repository(SensorReadingsContext dbContext) : base(dbContext)
        {
        }
    }
}
