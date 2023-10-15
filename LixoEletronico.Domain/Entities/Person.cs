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
            Reviews = new List<Review>();
        }

        public long Id { get; private set; }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public bool IsRepresentant { get; private set; }

        public List<Review>? Reviews { get; set; }

        public void UpdateEntity(Person person)
        {
            this.Name = person.Name;
            this.Email = person.Email;
            this.IsRepresentant = person.IsRepresentant;
        }
    }
}