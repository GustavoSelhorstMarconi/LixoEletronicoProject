namespace LixoEletronico.Shared.Dtos
{
    public class AddressDto
    {
        public int Id { get; set; }

        public short Number { get; set; }

        public string Street { get; set; }

        public string District { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
