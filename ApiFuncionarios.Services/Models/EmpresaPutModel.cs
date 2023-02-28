using System.ComponentModel.DataAnnotations;

namespace ApiFuncionarios.Services.Models
{
    public class EmpresaPutModel
    {
        public Guid idEmpresa { get; set; }

        [MinLength(6, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(50, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome fantasia da categoria.")]
        public string? nomeFantasia { get; set; }

        [MinLength(6, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(50, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe a razão social da categoria.")]
        public string? razaoSocial { get; set; }


        [MaxLength(14, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o CNPJ da empresa.")]
        public string? cnpj { get; set; }
    }
}
