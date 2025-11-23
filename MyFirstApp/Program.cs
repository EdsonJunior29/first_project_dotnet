using MyFirstApp.CustomMiddleware;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/map1", async (context) => {
    await context.Response.WriteAsync("In map 1");
});

app.MapPost("/map2", async (context) => {
    await context.Response.WriteAsync("In map 2");
});

//Nesse exemplo vamos criar uma URL de fallback
//Quando o usuário acessar uma URL inexistênte 
//Será redirecionado para a Fallback
app.MapFallback(async (context) => {
    await context.Response.WriteAsync($"Resquest received at {context.Request.Path}");
});

app.Run();
