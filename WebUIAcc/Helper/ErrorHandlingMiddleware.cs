using FluentValidation;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WebUIAcc.Helper
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        public ErrorHandlingMiddleware(RequestDelegate _next)
        {
            next = _next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        public static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            if (exception.GetType() == typeof(ValidationException))
            {
                var code = HttpStatusCode.BadRequest;
                var returnResult = JsonConvert.SerializeObject(new { result = 99, message = "Page information is not valid", Errors = ((ValidationException)exception).Errors });
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)code;
                await context.Response.WriteAsync(returnResult);
            }
            else
            {
                var _code = HttpStatusCode.InternalServerError;
                var _returnResult = JsonConvert.SerializeObject(new { result = 0, message = exception.Message });
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)_code;
                await context.Response.WriteAsync(_returnResult);
            }

        }
    }
}
