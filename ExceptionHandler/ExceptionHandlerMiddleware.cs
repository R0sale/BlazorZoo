using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ExceptionHandler.Converters;
using ExceptionHandler.Exceptions;
using Microsoft.AspNetCore.Http;

namespace ExceptionHandler
{
    public class ExceptionHandlerMiddleware
    {
        public RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(ex, context);
            }
        }

        private async Task HandleExceptionAsync(Exception ex, HttpContext context)
        {
            context.Response.ContentType = "application/json";

            context.Response.StatusCode = ex switch
            {
                NotFoundException => StatusCodes.Status404NotFound,
                BadRequestException => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status500InternalServerError
            };

            var serializeOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            serializeOptions.Converters.Add(new ExceptionResponseConverter());

            var response = JsonSerializer.Serialize(new ExceptionResponse
            {
                StatusCode = context.Response.StatusCode,
                Message = ex.Message
            }, serializeOptions);

            await context.Response.WriteAsync(response);
        }
    }
}
