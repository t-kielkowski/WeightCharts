namespace WeightCharts.Application.Dto
{
    public class BeehiveDataDto
    {
        public string BeehiveName { get; set; }
        public IEnumerable<Sht31TempDto> Temperature { get; set; }
        public IEnumerable<Sht31MoisDto> Moisture { get; set; }
    }
}