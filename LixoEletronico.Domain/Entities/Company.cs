namespace LixoEletronico.Domain.Entities
{
    public class Company
    {
        public Company(string name, int representantId, int addressId, Address address, byte[]? logo) : base()
        {
            Name = name;
            RepresentantId = representantId;
            AddressId = addressId;
            Address = address;
            Logo = logo;
        }

        protected Company()
        {
            Reviews = new List<Review>();
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public int RepresentantId { get; private set; }

        public Person? Representant { get; private set; }

        public int AddressId { get; private set; }

        public Address? Address { get; private set; }

        public byte[]? Logo { get; set; }

        public List<Review>? Reviews { get; set; }

        public void UpdateCompany(Company company)
        {
            Name = company.Name;
            RepresentantId = company.RepresentantId;
            AddressId = company.AddressId;
        }
    }
}
