using System.ComponentModel.DataAnnotations;

namespace Lista6.Models
{
    public class NovaPessoa
    {
        [Required(ErrorMessage = "Obrigatório")]
        [MaxLength(10, ErrorMessage = "Maximo 10 letras")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Obrigatório")]
        public string cpf {  get; set; }

        [Required(ErrorMessage = "Obrigatório")]
        public double peso { get; set; }

        [Required(ErrorMessage = "Obrigatório")]
        public double altura { get; set; }

    }
}
