namespace LixoEletronico.Domain.Entities
{
    public class Review
    {
        public Review(byte rating, string comment, int personId, int companyId) : base()
        {
            Rating = rating;
            Comment = comment;
            PersonId = personId;
            CompanyId = companyId;
        }

        protected Review()
        {
        }

        public int Id { get; private set; }

        public byte Rating { get; private set; }

        public string Comment { get; private set; }

        public int PersonId { get; private set; }

        public Person Person { get; set; }

        public int CompanyId { get; private set; }

        public Company Company { get; set; }
    }
}
