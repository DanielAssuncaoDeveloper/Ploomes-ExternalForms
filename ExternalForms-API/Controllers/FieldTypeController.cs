using ExternalForms_Domain.Dtos.FieldType;
using ExternalForms_Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExternalForms_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FieldTypeController : Controller
    {
        private readonly FieldTypeService _fieldTypeService;

        public FieldTypeController(FieldTypeService fieldTypeService)
        {
            _fieldTypeService = fieldTypeService;
        }

        /// <summary>
        /// Rota para realizar a consulta dos Tipos de Campos presentes para a vinculação dos Campos Customizados.
        /// </summary>
        /// <returns>
        ///     - 200: Lista com os dados dos Tipos de Campos
        ///     - 400: Mensagem de validação
        /// </returns>
        [HttpGet]
        public async Task<ActionResult<List<FieldTypeQueryDto>>> Consult() =>
            Ok(await _fieldTypeService.Consult());
    }
}
