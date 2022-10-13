namespace WeightChart.Infrastructure.DbModel
{
    public partial class Hdc1080
    {
        public uint Id { get; set; }
        public string? Temperature { get; set; }
        public string? Moisture { get; set; }
        public DateTime ReadingTime { get; set; }
    }
}
