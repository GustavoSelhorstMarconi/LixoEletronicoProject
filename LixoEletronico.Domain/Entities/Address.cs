using NetTopologySuite.Geometries;

namespace LixoEletronico.Domain.Entities
{
    public class Address
    {
        public Address(short number, string street, string district, string city, string state, string country) : base()
        {
            Number = number;
            Street = street;
            District = district;
            City = city;
            State = state;
            Country = country;
        }

        protected Address()
        {
        }

        public int Id { get; private set; }

        public short Number { get; private set; }

        public string Street { get; private set; }

        public string District { get; private set; }

        public string City { get; private set; }

        public string State { get; private set; }

        public string Country { get; private set; }

        public Point Location { get; set; }
    }
}
