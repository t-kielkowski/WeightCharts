namespace WeightChart.Infrastructure.DbModel
{
    public partial class Sht31test
    {
        public uint Id { get; set; }
        public string? Sensor { get; set; }
        public string? Temperature { get; set; }
        public string? Moisture { get; set; }
        public DateTime ReadingTime { get; set; }
        public string? BatteryLevel { get; set; }
    }
}
