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

        [HttpPost]
        public async Task<ActionResult<RegistrationReponseDto>> Register([FromBody] FormModelDto formModel) =>
            Ok(await _formModelService.Register(formModel));


        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromBody] FormModelDto formModel, int id)
        {
            await _formModelService.Update(formModel, id);
            return Ok();
        }

        [HttpPut("{id}/ChangeActivation")]
        public async Task<ActionResult<ChangeActivationResponseDto>> ChangeActivation(int id) =>
            Ok(await _formModelService.ChangeActivation(id));

        [HttpGet]
        public async Task<ActionResult<List<FormModelQueryDto>>> Consult([FromQuery] FormModelQueryFiltersDto queryFilter) =>
            Ok(await _formModelService.Consult(queryFilter));
    }
}
