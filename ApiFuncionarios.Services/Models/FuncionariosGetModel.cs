
namespace ApiFuncionarios.Services.Models
{
    public class FuncionariosGetModel
    {
        public Guid? idFuncionario { get; set; }
        public string? nome { get; set; }
        public string? matricula { get; set; }
        public string? cpf { get; set; }
        public DateTime? dataAdmissao { get; set; }
        public EmpresaGetModel? empresa { get; set; }
    }
}
