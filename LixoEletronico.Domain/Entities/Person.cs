using Microsoft.AspNetCore.Identity;

namespace LixoEletronico.Domain.Entities
{
    public class Person : IdentityUser<int>
    {
        public Person(string name, bool isRepresentant) : base()
        {
            Name = name;
            IsRepresentant = isRepresentant;
        }

        protected Person()
        {
            Companies = new List<Company>();
            Reviews = new List<Review>();
        }

        public string Name { get; private set; }

        public bool IsRepresentant { get; private set; }

        public string? RefreshToken { get; set; }

        public DateTime RefreshTokenExpiryTime { get; set; }

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