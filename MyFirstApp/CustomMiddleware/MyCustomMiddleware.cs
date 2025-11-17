
namespace MyFirstApp.CustomMiddleware
{
    public class MyCustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("My custom middleware\n");

            await next(context);

            await context.Response.WriteAsync("Sera apresentado no retorno da requisicao\n");
        }
    }


    /*Nesse teste a classe foi criada no mesmo diretório.
     * Mas podemos criá-la em outro local chamando a classe MyCustomMiddleware
     */
    public static class CustomMiddlewareExtension
    {
        public static IApplicationBuilder UseMyCustomMiddleware(this IApplicationBuilder app)
        { 
            return app.UseMiddleware<MyCustomMiddleware>();
        }
    }
}
