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

        /// <summary>
        /// Rota para realizar a inclusão de uma Resposta para o Modelo de Formulário.
        /// </summary>
        /// <param name="answer">Objeto com as informações das respostas.</param>
        /// <param name="idFormModel">Id do Modelo de Formulário que será respondido.</param>
        /// <returns>
        ///     - 200: Id da Resposta incluida
        ///     - 400: Mensagem de validação
        /// </returns>
        [HttpPost("/api/FormModel/{idFormModel}/Answer")]
        public async Task<ActionResult<RegistrationReponseDto>> Register([FromBody] AnswerDto answer, int idFormModel) =>
            Ok(await _answerService.Register(answer, idFormModel));

        /// <summary>
        /// Rota para realizar a consulta das Respostas aplicadas a um Modelo de Formulário.
        /// </summary>
        /// <param name="idFormModel">
        ///     - 200: Lista com os dados de Resposta ao Modelo de Formulário
        ///     - 400: Mensagem de validação
        /// </param>
        /// <returns></returns>
        [HttpGet("/api/FormModel/{idFormModel}/Answer")]
        public async Task<ActionResult<List<AnswerQueryDto>>> Consult(int idFormModel) =>
            Ok(await _answerService.Consult(idFormModel));

    }
}
