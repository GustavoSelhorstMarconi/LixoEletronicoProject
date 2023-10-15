namespace LixoEletronico.Domain.Entities
{
    public class Company
    {
        public Company(string name, long representantId, Person representant) : base()
        {
            Name = name;
            RepresentantId = representantId;
            Representant = representant;
        }

        protected Company()
        {
            Reviews = new List<Review>();
        }

        public long Id { get; private set; }

        public string Name { get; private set; }

        public long RepresentantId { get; private set; }

        public Person Representant { get; private set; }

        public long AddressId { get; private set; }

        public Address Address { get; private set; }

        public List<Review> Reviews { get; set; }
    }
}
