using System.ComponentModel.DataAnnotations;

namespace ApiFuncionarios.Services.Models
{
    public class FuncionariosPostModel
    {
        [MinLength(6, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(50, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do funcionario.")]
        public string?  nome { get; set; }

        [MinLength(6, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(50, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe a amtricula do funcionario")]
        public string? matricula{ get; set; }

        [MinLength(11, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o CPF do funcionario.")]
        public string? cpf { get; set; }
        public DateTime? dataAdmissao { get; set; }
        public Guid idEmpresa { get; set; }
    }
}
