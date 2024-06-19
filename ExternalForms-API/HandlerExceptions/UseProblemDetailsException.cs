using ExternalForms_API.HandlerExceptions.Exceptions;
using ExternalForms_Data.Exceptions;
using ExternalForms_Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;
using System.Net;

namespace ExternalForms_API.HandlerExceptions
{
    /// <summary>
    /// Middleware para capturar as Exceptions lançadas ao decorrer do programa
    /// </summary>
    internal static class UseProblemDetailsException
    {
        internal static void UseProblemDetailsExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (exceptionHandlerFeature != null)
                    {
                        Exception exception = exceptionHandlerFeature.Error;
                        await ChangeResponseForExceptionMessage(exception, context);
                    }
                });
            });
        }

        internal static async Task ChangeResponseForExceptionMessage(Exception exception, HttpContext context)
        {
            string message = string.Empty;
            var statusCode = HttpStatusCode.BadRequest;

            // Verificando as Exceptions customizadas para aplicar tratamento na resposta
            switch (exception)
            {
                case ApiLayerException apiLayerException:
                    message = apiLayerException.Message;
                    break;

                case DomainLayerException domainLayerException:
                    message = domainLayerException.Message;
                    break;
                
                case DataLayerException dataLayerException:
                    message = dataLayerException.Message;
                    break;

                default:
                    // Enviando mensagem genérica para Exception não mapeada
                    message = "Erro interno. Entre em contato com o suporte para mais detalhes.";
                    break;
            }

            await ChangeHttpResponse(context, message, statusCode);
        }

        private static async Task ChangeHttpResponse(HttpContext context, string message, HttpStatusCode httpStatus)
        {
            // Alterando o reponse da rota para a mensagem de erro enviada
            context.Response.StatusCode = (int)httpStatus;
            context.Response.ContentType = "application/problem+json";

            var json = JsonConvert.SerializeObject(new { Message = message }, new JsonSerializerSettings().Formatting);
            await context.Response.WriteAsync(json);
        }
    }
}
