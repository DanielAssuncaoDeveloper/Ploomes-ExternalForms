using ExternalForms_Domain.Dtos.Answer;
using ExternalForms_Domain.Dtos.Commum;
using ExternalForms_Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExternalForms_API.Controllers
{
    [Route("api/FormModel/[controller]")]
    [ApiController]
    public class AnswerController : Controller
    {
        private readonly AnswerService _answerService;

        public AnswerController(AnswerService answerService)
        {
            _answerService = answerService;
        }

        [HttpPost("/api/FormModel/{idFormModel}/Answer")]
        public async Task<ActionResult<RegistrationReponseDto>> Register([FromBody] AnswerDto answer, int idFormModel) =>
            Ok(await _answerService.Register(answer, idFormModel));

        [HttpGet("/api/FormModel/{idFormModel}/Answer")]
        public async Task<ActionResult<List<AnswerQueryDto>>> Consult(int idFormModel) =>
            Ok(await _answerService.Consult(idFormModel));

    }
}
