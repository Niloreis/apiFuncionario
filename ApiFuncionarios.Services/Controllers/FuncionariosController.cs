
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

    public class FuncionariosController : ControllerBase
    {
        //atributo
        private readonly IMapper _mapper;

        //construtor para inicialização dos atributos
        public FuncionariosController(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Serviço para cadastro de produto na API
        /// </summary>
        [HttpPost]
        public IActionResult Post(FuncionariosPostModel model)
        {
            try
            {
                var funcionario = _mapper.Map<Funcionario>(model);

                var funcionarioRepository = new FuncionarioRepository();
                funcionarioRepository.Add(funcionario);

                return StatusCode(201, new
                {
                    mensagem = "Produto cadastrado com sucesso.",
                    produto = _mapper.Map<FuncionariosGetModel>(funcionarioRepository.GetById(funcionario.IdFuncionario))
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = "Falha ao cadastrar produto: " + e.Message });
            }
        }

        /// <summary>
        /// Serviço para edição de produto na API
        /// </summary>
        [HttpPut]
        public IActionResult Put(FuncionariosPutModel model)
        {
            try
            {
                var funcionarioRepository = new FuncionarioRepository();



                var funcionario = _mapper.Map<Funcionario>(model);


                funcionarioRepository.Update(funcionario);

                return StatusCode(200, new
                {
                    mensagem = "Produto atualizado com sucesso.",
                    funcionario = _mapper.Map<FuncionariosGetModel>(funcionarioRepository.GetById(funcionario.IdFuncionario))
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = "Falha ao atualizar produto: " + e.Message });
            }
        }

        /// <summary>
        /// Serviço para exclusão de produto na API
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid? id)
        {
            try
            {
                var funcionarioRepository = new FuncionarioRepository();
                var funcionario = funcionarioRepository.GetById(id);

                if (funcionario == null)
                    return StatusCode(404,new { mensagem = "Produto não encontrado." });

                funcionarioRepository.Delete(funcionario);

                return StatusCode(200, new
                {
                    mensagem = "Produto excluído com sucesso.",
                    produto = _mapper.Map<FuncionariosGetModel>(funcionario)
                });
            }
            catch (Exception e)
            {
                return StatusCode(500,new{ mensagem = "Falha ao excluir produto: "+ e.Message});
            }
        }


        /// <summary>
        /// Serviço para consultar todos os produtos na API
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(List<FuncionariosGetModel>), 200)]
        public IActionResult GetAll()
        {
            try
            {
                var funcionarioRepository = new FuncionarioRepository();
                var funcionario = funcionarioRepository.GetAll();

                return StatusCode(200, _mapper.Map<List<FuncionariosGetModel>>(funcionario));

            }
            catch (Exception e)
            {
                return StatusCode(500,new{mensagem = "Falha ao consultar produtos: "+ e.Message});
            }
        }

        /// <summary>
        /// Serviço para consultar 1 produto na API
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(FuncionariosGetModel), 200)]
        public IActionResult GetById(Guid? id)
        {
            try
            {
                var funcionarioRepository = new FuncionarioRepository();
                var funcionario = funcionarioRepository.GetById(id);

                if (funcionario == null)
                    return StatusCode(404,new { mensagem = "Produto não encontrado." });

                return StatusCode(200, _mapper.Map<FuncionariosGetModel>(funcionario));
            }
            catch (Exception e)
            {
                return StatusCode(500,new{mensagem = "Falha ao obter produto: "+ e.Message});
            }
        }
   }
}
