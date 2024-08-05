namespace LixoEletronico.Shared.Dtos
{
    public class CompanyDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int RepresentantId { get; set; }

        public PersonDto? Representant { get; set; }

        public int AddressId { get; set; }

        public AddressDto Address { get; set; }

        public float ReviewAverage { get; set; }

        public double Distance { get; set; }

        public double LatitudeBase { get; set; }

        public double LongitudeBase { get; set; }

        public byte[]? Logo { get; set; }

        public string? LogoRetorno { get; set; }

        public List<ReviewDto>? Reviews { get; set; }
    }
}
