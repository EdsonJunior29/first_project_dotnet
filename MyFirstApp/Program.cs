using MyFirstApp.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);

//Injeção de dependência
// deverá ser adicionada antes do comando: var app = builder.Build();
builder.Services.AddTransient<MyCustomMiddleware>();

var app = builder.Build();

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Middleware 1\n");
    await next(context);
});


/*Nesse exemplo adicionei o middleware personalizado
 * após o 1° middleware. Mas posso adicionar ele como o 
 * 1° se eu quiser.
 * Nesse exemplo estou chamando o método da classe estática
 */
app.UseMyCustomMiddleware();

app.Run(async (context) =>
{
    await context.Response.WriteAsync("Middleware 3");
});

app.Run();
