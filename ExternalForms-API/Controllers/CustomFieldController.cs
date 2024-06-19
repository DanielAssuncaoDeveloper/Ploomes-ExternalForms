using ExternalForms_Domain.Dtos.Commum;
using ExternalForms_Domain.Dtos.CustomField;
using ExternalForms_Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExternalForms_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomFieldController : Controller
    {
        private readonly CustomFieldService _customFieldService;

        public CustomFieldController(CustomFieldService customFieldService)
        {
            _customFieldService = customFieldService;
        }

        [HttpPost("/api/FormModel/{idFormModel}/CustomField")]
        public async Task<ActionResult<RegistrationReponseDto>> Register([FromBody] CustomFieldDto customField, int idFormModel) =>
            Ok(await _customFieldService.Register(customField, idFormModel));

        [HttpPut("/api/FormModel/CustomField/{id}")]
        public async Task<ActionResult> Update([FromBody] CustomFieldDto customField, int id)
        {
            await _customFieldService.Update(customField, id);
            return Ok();
        }

        [HttpPut("/api/FormModel/CustomField/{id}/ChangeActivation")]
        public async Task<ActionResult<ChangeActivationResponseDto>> ChangeActivation(int id) =>
            Ok(await _customFieldService.ChangeActivation(id));

        [HttpGet("/api/FormModel/{idFormModel}/CustomField/")]
        public async Task<ActionResult<List<CustomFieldQueryDto>>> Consult([FromQuery] QueryFiltersBaseDto queryFilters) =>
            Ok(await _customFieldService.Consult(queryFilters));

    }
}
