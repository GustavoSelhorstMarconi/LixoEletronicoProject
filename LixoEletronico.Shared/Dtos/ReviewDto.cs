using AutoMapper.Configuration.Annotations;

namespace LixoEletronico.Shared.Dtos
{
    public class ReviewDto
    {
        public int Id { get; set; }

        public byte Rating { get; set; }

        public string Comment { get; set; }

        public int PersonId { get; set; }

        [SourceMember("Review.Person.Name")]
        public string? PersonName { get; set; }

        public int CompanyId { get; set; }
    }
}
