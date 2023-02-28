

namespace ApiFuncionarios.Services.Models
{
    public class EmpresaGetModel
    {
        public Guid idEmpresa { get; set; }
        public string? nomeFantasia { get; set; }
        public string? razaoSocial { get; set; }
        public string? cnpj { get; set; }
        public DateTime? dataHoraCadastro { get; set; }
    }
}
