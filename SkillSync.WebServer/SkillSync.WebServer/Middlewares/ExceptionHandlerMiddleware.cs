using SkillSync.Domain.DTOs;
using SkillSync.Domain.Exceptions;
using System.Net;

namespace SkillSync.WebServer.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        readonly RequestDelegate next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (ExceptionBase ex)
            {
                await RespondToExceptionAsync(context, ex.StatusCode, ex.Message, true);
            }
            catch (Exception ex)
            {
                await RespondToExceptionAsync(context, HttpStatusCode.InternalServerError, ex.Message, false);
            }
        }

        private static Task RespondToExceptionAsync(HttpContext context, HttpStatusCode failureStatusCode, string message, bool isCustom)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)failureStatusCode;

            return context.Response.WriteAsync(new ErrorDetails()
            {
                HttpCodeStatus = failureStatusCode,
                Message = message,
                IsCustom = isCustom
            }.ToString());
        }
    }
}