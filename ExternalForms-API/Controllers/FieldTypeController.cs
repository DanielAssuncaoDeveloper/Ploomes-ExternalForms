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

        [HttpGet]
        public async Task<ActionResult<List<FieldTypeQueryDto>>> Consult() =>
            Ok(await _fieldTypeService.Consult());
    }
}
