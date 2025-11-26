using MyFirstApp.CustomMiddleware;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/map1/{filename}", async (context) => {
    await context.Response.WriteAsync($"In map 1 {filename}");
});

app.MapPost("/map2", async (context) => {
    await context.Response.WriteAsync("In map 2");
});

app.MapGET("/map3/{Employee=edson}", async (context) => {
    await context.Response.WriteAsync("In map 3: {Employee}");
});

app.MapGET("/map4/{Employee?}", async (context) => {
    await context.Response.WriteAsync("In map 4: {Employee}");
});

//Contraits informa o tipo do parâmetros que devemos passar
//para o endpoint
app.MapGET("/map5/{id:int?}", async (context) => {
    await context.Response.WriteAsync("In map 5: {id}");
});

app.MapGET("/map6/{day:datetime}", async (context) => {
    await context.Response.WriteAsync("In map 6: {day}");
});

//Nesse exemplo vamos criar uma URL de fallback
//Quando o usuário acessar uma URL inexistênte 
//Será redirecionado para a Fallback
app.MapFallback(async (context) => {
    await context.Response.WriteAsync($"Resquest received at {context.Request.Path}");
});

app.Run();
