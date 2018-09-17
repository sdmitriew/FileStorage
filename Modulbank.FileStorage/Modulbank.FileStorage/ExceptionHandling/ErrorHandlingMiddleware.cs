using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Logging;
using Modulbank.FileStorage.BL.Contracts.CustomExceptions;
using Modulbank.FileStorage.BL.Contracts.ErrorCodes;
using Modulbank.FileStorage.Dto.Response;
using Newtonsoft.Json;

namespace Modulbank.FileStorage.ExceptionHandling
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next,
            ILoggerFactory loggerFactory)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                var startTime = DateTime.UtcNow;
                var watch = Stopwatch.StartNew();
                await _next.Invoke(context);
                watch.Stop();
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private string FormatRequest(HttpRequest request)
        {
            var body = request.Body;
            request.EnableRewind();

            var buffer = new byte[Convert.ToInt32(request.ContentLength)];
            request.Body.Read(buffer, 0, buffer.Length);
            var bodyAsText = Encoding.UTF8.GetString(buffer);
            request.Body = body;

            return $"{request.Scheme} {request.Host}{request.Path} {request.QueryString} {bodyAsText}";
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            string result;
            if (exception is NotFileCustomException ex)
                result = JsonConvert.SerializeObject(new ErrorResponse { Message = ex.Message, Code = ex.ErrorCode });

            else
                result = JsonConvert.SerializeObject(new ErrorResponse { Message = exception.Message, Code = ExceptionCode.FatalExceptionCode });

            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(result);
        }
    }
}
