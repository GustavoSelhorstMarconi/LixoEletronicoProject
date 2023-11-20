using System.ComponentModel.DataAnnotations;

namespace LixoEletronico.Application.Dtos
{
    public class PersonDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        [Display(Name = "e-mail")]
        [EmailAddress(ErrorMessage = "É necessário ser um {0} válido.")]
        public string? Email { get; set; }

        public bool IsRepresentant { get; set; }
    }
}
