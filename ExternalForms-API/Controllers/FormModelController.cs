using ExternalForms_Domain.Dtos.Commum;
using ExternalForms_Domain.Dtos.FormModel;
using ExternalForms_Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExternalForms_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormModelController : Controller
    {
        private readonly FormModelService _formModelService;

        public FormModelController(FormModelService formModelService)
        {
            _formModelService = formModelService;
        }

        /// <summary>
        /// Rota para realizar o cadastro do Modelo de Formulário.
        /// </summary>
        /// <param name="formModel">Objeto com as informações iniciais do formulário.</param>
        /// <returns>
        ///     - 200: Id do formulário incluido
        ///     - 400: Mensagem de validação
        /// </returns>
        [HttpPost]
        public async Task<ActionResult<RegistrationReponseDto>> Register([FromBody] FormModelDto formModel) =>
            Ok(await _formModelService.Register(formModel));

        /// <summary>
        /// Rota para realizar a alteração do Modelo de Formulário.
        /// </summary>
        /// <param name="formModel">Objeto com as informações iniciais do formulário.</param>
        /// <param name="id">Id do Modelo de Formulário.</param>
        /// <returns>
        ///     - 200
        ///     - 400: Mensagem de validação
        /// </returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromBody] FormModelDto formModel, int id)
        {
            await _formModelService.Update(formModel, id);
            return Ok();
        }

        /// <summary>
        /// Rota para realizar a ativação/inativação do Modelo de Formulário.
        /// </summary>
        /// <param name="id">Id do Modelo de Formulário.</param>
        /// <returns>
        ///     - 200: Status de ativação do Modelo de Formulário
        ///     - 400: Mensagem de validação
        /// </returns>
        [HttpPut("{id}/ChangeActivation")]
        public async Task<ActionResult<ChangeActivationResponseDto>> ChangeActivation(int id) =>
            Ok(await _formModelService.ChangeActivation(id));

        /// <summary>
        /// Rota para realizar a consulta dos Modelos de Formulário.
        /// </summary>
        /// <param name="queryFilter">Objeto com informações para a filtragem dos Modelos de Formulário.</param>
        /// <returns>
        ///     - 200: Lista com os dados dos Modelos de Formulários 
        ///     - 400: Mensagem de validação
        /// </returns>
        [HttpGet]
        public async Task<ActionResult<List<FormModelQueryDto>>> Consult([FromQuery] FormModelQueryFiltersDto queryFilter) =>
            Ok(await _formModelService.Consult(queryFilter));
    }
}
