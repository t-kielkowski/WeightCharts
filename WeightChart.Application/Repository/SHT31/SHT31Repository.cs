using WeightChart.Infrastructure.DbModel;

namespace WeightChart.Infrastructure.Repository
{
    public class SHT31Repository : BaseRepository<Sht31>, ISHT31Repository
    {
        public SHT31Repository(SensorReadingsContext dbContext) : base(dbContext)
        {
        }
    }
}
