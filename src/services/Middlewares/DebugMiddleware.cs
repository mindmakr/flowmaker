using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace services.Middlewares
{
    public class DebugMiddleware
    {
        private readonly RequestDelegate _next;

        public DebugMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);
            // Inspecting or updating response
            var newBody = new MemoryStream();
            //newBody.Seek(0, SeekOrigin.Begin);
            //var newContent = new StreamReader(newBody).ReadToEnd();
            var newContent = ", Copyright (c) 2020 Mindmakr Limited.";
            await context.Response.WriteAsync(newContent);
        }
    }

    public static class DebugMiddlewareExtensions
    {
        public static IApplicationBuilder UseDebug(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DebugMiddleware>();
        }
    }
}
