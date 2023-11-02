namespace LixoEletronico.Domain.Entities
{
    public class Person
    {
        public Person(string name, bool isRepresentant, string email) : base()
        {
            Name = name;
            Email = email;
            IsRepresentant = isRepresentant;
        }

        protected Person()
        {
            Companies = new List<Company>();
            Reviews = new List<Review>();
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public bool IsRepresentant { get; private set; }

        public List<Company>? Companies { get; private set; }

        public List<Review>? Reviews { get; private set; }

        public void UpdatePerson(Person person)
        {
            Name = person.Name;
            Email = person.Email;
            IsRepresentant = person.IsRepresentant;
        }
    }
}