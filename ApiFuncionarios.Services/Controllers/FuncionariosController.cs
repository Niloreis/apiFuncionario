using ApiFuncionarios.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiFuncionarios.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
            /// <summary>
            /// Serviço para cadastro de categoria na API
            /// </summary>
            [HttpPost]
            public IActionResult Post(FuncionariosPostModel model)
            {
                return Ok();
            }

            /// <summary>
            /// Serviço para edição de categoria na API
            /// </summary>
            [HttpPut]
            public IActionResult Put(FuncionariosPutModel model)
            {
                return Ok();
            }

        /// <summary>
        /// Serviço para exclusão de categoria na API
        /// </summary>
        [HttpDelete("{id}")]
            public IActionResult Delete(Guid? id)
            {
                return Ok();
            }

        /// <summary>
        /// Serviço para consultar todas as categorias na API
        /// </summary>
        [HttpGet]
            [ProducesResponseType(typeof(List<FuncionariosGetModel>),200)]
            public IActionResult GetAll()
            {
                return Ok();
            }

            /// <summary>
            /// Serviço para consultar 1 categoria na API
            /// </summary>
            [HttpGet("{id}")]
            [ProducesResponseType(typeof(FuncionariosGetModel),200)]
            public IActionResult GetById(Guid? id)
            {
                return Ok();
            }
    }

}




