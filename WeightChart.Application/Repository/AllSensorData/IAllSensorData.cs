namespace WeightChart.Infrastructure.Repository
{
    public interface IAllSensorData
    {
        IBH1750Repository bH1750Repository { get; }
        IBMP280Repository bMP280Repository { get; }
        IHDC1080Repository hDC1080Repository { get; }
        ISHT31Repository sHT31Repository { get; }
        ISHT31TestRepository sHT31TestRepository { get; }
        ISoilMoistureRepository soilMoistureRepository { get; }
    }
}
