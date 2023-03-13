
using ApiFuncionarios.Data.Entities;
using ApiFuncionarios.Services.Models;
using AutoMapper;

namespace ApiProdutos.Services.Mappings
{
    /// <summary>
    /// Mapear transferencias de dados de Models para Entities
    /// </summary>
    public class ModelToEntityMap : Profile
    {
        //método construtor
        public ModelToEntityMap()
        {
            CreateMap<EmpresaPostModel, Empresa>()
                .AfterMap((src, dest) =>
                {
                    dest.IdEmpresa = Guid.NewGuid();
                });

            CreateMap<EmpresaPutModel, Empresa>();

            CreateMap<FuncionariosPostModel, Funcionario>()
                .AfterMap((src, dest) =>
                {
                    dest.IdFuncionario = Guid.NewGuid();
                });

            CreateMap<FuncionariosPutModel, Funcionario>();
        }
    }
}

