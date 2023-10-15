namespace LixoEletronico.Domain.Entities
{
    public class Review
    {
        public Review(int rating, string comment, long personId, Person person, long companyId, Company company) : base()
        {
            Rating = rating;
            Comment = comment;
            PersonId = personId;
            Person = person;
            CompanyId = companyId;
            Company = company;
        }

        protected Review()
        {
        }

        public long Id { get; private set; }

        public int Rating { get; private set; }

        public string Comment { get; private set; }

        public long PersonId { get; private set; }

        public Person Person { get; private set; }

        public long CompanyId { get; private set; }

        public Company Company { get; set; }
    }
}
