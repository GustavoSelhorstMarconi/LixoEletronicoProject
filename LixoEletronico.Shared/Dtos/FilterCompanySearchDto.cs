namespace LixoEletronico.Shared.Dtos
{
    public class FilterCompanySearchDto
    {
        public string Name { get; set; }

        public double? MinDistance { get; set; }

        public double? MaxDistance { get; set; }

        public double LatitudeBase { get; set; }

        public double LongitudeBase { get; set; }
    }
}
