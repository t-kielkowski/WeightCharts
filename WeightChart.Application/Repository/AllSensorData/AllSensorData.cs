using Microsoft.Extensions.Configuration;

namespace WeightChart.Infrastructure.Repository
{
    public class AllSensorData : IAllSensorData
    {
        protected readonly IConfiguration _configuration;

        public AllSensorData(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IBH1750Repository bH1750Repository  => new BH1750Repository(new SensorReadingsContext(_configuration));

        public IBMP280Repository bMP280Repository => new BMP280Repository(new SensorReadingsContext(_configuration));

        public IHDC1080Repository hDC1080Repository => new HDC1080Repository(new SensorReadingsContext(_configuration));

        public ISHT31Repository sHT31Repository => new SHT31Repository(new SensorReadingsContext(_configuration));

        public ISHT31TestRepository sHT31TestRepository => new SHT31TestRepository(new SensorReadingsContext(_configuration));

        public ISoilMoistureRepository soilMoistureRepository => new SoilMoistureRepository(new SensorReadingsContext(_configuration));
    }
}
