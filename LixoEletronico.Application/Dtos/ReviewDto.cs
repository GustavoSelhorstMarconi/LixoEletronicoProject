namespace LixoEletronico.Application.Dtos
{
    public class ReviewDto
    {
        public int Id { get; set; }

        public byte Rating { get; set; }

        public string Comment { get; set; }

        public int PersonId { get; set; }

        public int CompanyId { get; set; }
    }
}
