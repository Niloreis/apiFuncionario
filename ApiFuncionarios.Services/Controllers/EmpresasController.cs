using ApiFuncionarios.Data.Entities;
using ApiFuncionarios.Data.Repositories;
using ApiFuncionarios.Services.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiFuncionarios.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        //atributo
        private readonly IMapper _mapper;

        //construtor para inicializar os atributos da classe
        public EmpresasController(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Serviço para cadastro de categoria na API
        /// </summary>

        [HttpPost]
        public IActionResult Post(EmpresaPostModel model)
        {
            try
            {
                var empresa = _mapper.Map<Empresa>(model);

                var empresaRepository = new EmpresaRepository();
                empresaRepository.Add(empresa);

                //HTTP 201 (CREATED)
                return StatusCode(201, new
                {
                    mensagem = "Categoria cadastrada com sucesso.",
                    empresa = _mapper.Map<EmpresaGetModel>(empresa)
                });
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500,new{ mensagem = "Falha ao cadastrar categoria: "+ e.Message});
            }
        }

        /// <summary>
        /// Serviço para edição de categoria na API
        /// </summary>
        [HttpPut]
        public IActionResult Put(EmpresaPutModel model)
        {
            try
            {
                var empresaRepository = new EmpresaRepository();

                if (empresaRepository.GetById(model.idEmpresa) == null)
                    return StatusCode(404,new { mensagem = "Categoria não encontrada." });

                var empresa = _mapper.Map<Empresa>(model);
                empresaRepository.Update(empresa);

                //HTTP 200 (OK)
                return StatusCode(200, new
                {
                    mensagem = "Categoria atualizada com sucesso.",
                    empresa = _mapper.Map<EmpresaGetModel>(empresa)
                });
            }



            catch (Exception e)
            {
                return StatusCode(500,new{mensagem = "Falha ao atualizar categoria: "+ e.Message});
            }
        }

        /// <summary>
        /// Serviço para exclusão de categoria na API
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid? id)
        {
            try
            {
                var empresaRepository = new EmpresaRepository();
                var empresa = empresaRepository.GetById(id);

                if (empresa == null)
                    return StatusCode(404,new { mensagem = "Categoria não encontrada." });

                empresaRepository.Delete(empresa);

                //HTTP 200 (OK)
                return StatusCode(200, new
                {
                    mensagem = "Categoria excluída com sucesso.",
                    empresa = _mapper.Map<EmpresaGetModel>(empresa)
                });
            }
            catch (Exception e)
            {
                return StatusCode(500,new{mensagem = "Falha ao excluir categoria: "+ e.Message});
            }
        }

        /// <summary>
        /// Serviço para consultar todas as categorias na API
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(List<EmpresaGetModel>), 200)]
        public IActionResult GetAll()
        {
            try
            {
                var empresaRepository = new EmpresaRepository();
                var empresa = empresaRepository.GetAll();


                return StatusCode(200, _mapper.Map<List<EmpresaGetModel>>(empresa));
            }
            catch (Exception e)
            {
                return StatusCode(500,new {mensagem = "Erro ao consultar categorias: "+ e.Message});
            }
        }

        /// <summary>
        /// Serviço para consultar 1 categoria na API
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EmpresaGetModel), 200)]
        public IActionResult GetById(Guid? id)
        {
            try
            {
                var empresaRepository = new EmpresaRepository();
                var empresa = empresaRepository.GetById(id);

                if (empresa == null)
                    return StatusCode(404,new { mensagem = "Categoria não encontrada." });
                else
                    return StatusCode(200, _mapper.Map<EmpresaGetModel>(empresa));
            }
            catch (Exception e)
            {
                return StatusCode(500,new{mensagem = "Erro ao obter categoria: "+ e.Message});
            }
        }
    }
}

