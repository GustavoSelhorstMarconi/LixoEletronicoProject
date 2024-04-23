namespace LixoEletronico.Application.Dtos
{
    public class FilterCompanySearchDto
    {
        public string Name { get; set; }

        public long MinDistance { get; set; }

        public long MaxDistance { get; set; }
    }
}
