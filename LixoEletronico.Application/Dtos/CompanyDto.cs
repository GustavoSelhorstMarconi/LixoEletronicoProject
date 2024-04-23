namespace LixoEletronico.Application.Dtos
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
    }
}
