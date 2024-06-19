using ExternalForms_Domain.Dtos.Commum;
using ExternalForms_Domain.Dtos.CustomField;
using ExternalForms_Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExternalForms_API.Controllers
{
    [Route("api/FormModel/[controller]")]
    [ApiController]
    public class CustomFieldController : Controller
    {
        private readonly CustomFieldService _customFieldService;

        public CustomFieldController(CustomFieldService customFieldService)
        {
            _customFieldService = customFieldService;
        }

        /// <summary>
        /// Rota para realizar o cadastro dos Campos Customizados.
        /// </summary>
        /// <param name="customField">Objeto com as informações do Campo Customizado.</param>
        /// <param name="idFormModel">Id do Modelo de Formulário que os Campos Customizados serão vinculados.</param>
        /// <returns>
        ///     - 200: Id do Campo Customizado incluido
        ///     - 400: Mensagem de validação
        /// </returns>

        [HttpPost("/api/FormModel/{idFormModel}/CustomField")]
        public async Task<ActionResult<RegistrationReponseDto>> Register([FromBody] CustomFieldDto customField, int idFormModel) =>
            Ok(await _customFieldService.Register(customField, idFormModel));

        /// <summary>
        /// Rota para realizar a alteração dos Campos Customizados.
        /// </summary>
        /// <param name="customField">Objeto com as informações do Campo Customizado.</param>
        /// <param name="id">Id do Campo Customizado a ser alterado.</param>
        /// <returns>
        ///     - 200
        ///     - 400: Mensagem de validação
        /// </returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromBody] CustomFieldDto customField, int id)
        {
            await _customFieldService.Update(customField, id);
            return Ok();
        }

        /// <summary>
        /// Rota para realizar a ativação/inativação do Campo Customizado.
        /// </summary>
        /// <param name="id">Id do Campo Customizado.</param>
        /// <returns>
        ///     - 200: Status de ativação do Campo Customizado
        ///     - 400: Mensagem de validação
        /// </returns>
        [HttpPut("{id}/ChangeActivation")]
        public async Task<ActionResult<ChangeActivationResponseDto>> ChangeActivation(int id) =>
            Ok(await _customFieldService.ChangeActivation(id));


        /// <summary>
        /// Rota para realizar a consulta dos Campos Customizados com base em um Modelo de Formulário.
        /// </summary>
        /// <param name="queryFilter">Objeto com informações para a filtragem dos Campos Customizados.</param>
        /// <returns>
        ///     - 200: Lista com os dados dos Modelos de Formulários 
        ///     - 400: Mensagem de validação
        /// </returns>
        [HttpGet("/api/FormModel/{idFormModel}/CustomField/")]
        public async Task<ActionResult<List<CustomFieldQueryDto>>> Consult([FromQuery] QueryFiltersBaseDto queryFilters) =>
            Ok(await _customFieldService.Consult(queryFilters));

    }
}
