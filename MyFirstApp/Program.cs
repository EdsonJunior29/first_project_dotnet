var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    context.Response.StatusCode = 200;

    //Retornando dados no Headers da requisição
    context.Response.Headers["X-Custom-Header"] = "MyFirstAppHeaderValue";

    //Retornando informações do servidor
    context.Response.Headers["Server"] = "MyFirstAppServer/1.0";

    //Retornando o content-type da resposta
    context.Response.Headers["Content-Type"] = "text/plain; charset=utf-8";

    //Dado que será retorna na resposta da requisição
    await context.Response.WriteAsync("Hello, World!");

    
});

app.Run();
