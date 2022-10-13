using WeightChart.Infrastructure.DbModel;

namespace WeightChart.Infrastructure.Repository
{
    public class SHT31TestRepository : BaseRepository<Sht31test>, ISHT31TestRepository
    {
        public SHT31TestRepository(SensorReadingsContext dbContext) : base(dbContext)
        {
        }
    }
}
