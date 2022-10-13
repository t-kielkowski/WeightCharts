namespace WeightChart.Infrastructure.DbModel
{
    public partial class Bmp280
    {
        public uint Id { get; set; }
        public string? Temperature { get; set; }
        public string? Pressure { get; set; }
        public DateTime ReadingTime { get; set; }
    }
}
