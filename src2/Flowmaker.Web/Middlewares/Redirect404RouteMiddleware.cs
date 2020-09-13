using Flowmaker.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Flowmaker.Web.Middlewares
{
    public class Redirect404RouteMiddleware
    {
        private readonly RequestDelegate _next;
        public Redirect404RouteMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ApplicationDbContext dbContext)
        {
            
            await _next(context);
            if (context.Response.StatusCode == 404)
            {
                var hostname = context.Request.Host.Host.ToLower();
                var path = context.Request.Path.ToString().ToLower();
                var flow = dbContext.Flows.Include(f => f.Environment).FirstOrDefault(f => f.Slug == path && f.Environment.Hostname.ToLower()==hostname);
                if (flow != null)
                {
                    context.Request.Path = "/";
                }
                else
                {
                    context.Request.Path = "/Home/Page404";
                }
                await _next(context);
            }
        }
    }

    public static class Redirect404RouteMiddlewareExtensions
    {
        public static IApplicationBuilder UseRedirect404Route(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Redirect404RouteMiddleware>();
        }
    }
}
