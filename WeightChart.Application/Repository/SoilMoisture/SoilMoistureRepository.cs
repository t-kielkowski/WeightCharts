using WeightChart.Infrastructure.DbModel;

namespace WeightChart.Infrastructure.Repository
{
    public class SoilMoistureRepository : BaseRepository<SoilMoisture>, ISoilMoistureRepository
    {
        public SoilMoistureRepository(SensorReadingsContext dbContext) : base(dbContext)
        {
        }
    }
}
