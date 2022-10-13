using WeightChart.Infrastructure.DbModel;

namespace WeightCharts.ViewModel
{
    public class Sht31TempDto
    {
        public string ReadingTime { get; set; }
        public string Temperature { get; set; }

    }

    public class Sht31MoisDto
    {
        public double Moisture { get; set; }
        public DateTime ReadingTime { get; set; }
    }

    public static class Sht31ViewModel
    {
        public static Sht31TempDto ToTemperatureViewModel(this Sht31 sensor)
        {
            return new Sht31TempDto
            {
                ReadingTime = sensor.ReadingTime.ToString(),
                Temperature = sensor.Temperature
            };
        }

        public static Sht31MoisDto ToMoistureViewModel(this Sht31 sensor)
        {
            return new Sht31MoisDto
            {
                Moisture = string.IsNullOrEmpty(sensor.Moisture) ? 0 : double.Parse(sensor.Moisture),
                ReadingTime = sensor.ReadingTime
            };
        }
    }
}
