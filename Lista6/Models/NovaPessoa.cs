using System.ComponentModel.DataAnnotations;

namespace Lista6.Models
{
    public class NovaPessoa
    {
        [Required(ErrorMessage = "Obrigatório")]
        [MaxLength(100, ErrorMessage = "Maximo 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório")]
        [MinLength(11, ErrorMessage = "CPF deve ter pelo manos 11 dígitos")]
        [MaxLength(14, ErrorMessage = "CPF deve ter no máximo 14 dígitos")]
        public string Cpf {  get; set; }

        [Required(ErrorMessage = "Obrigatório")]
        public double Peso { get; set; }

        [Required(ErrorMessage = "Obrigatório")]
        public double Altura { get; set; }

    }
}
