using MyFirstApp.CustomMiddleware;
using static System.Net.Mime.MediaTypeNames;

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

//Custom Middleware criado
//clicar em add > new item > middleware
app.UseHelloCustomMiddleware();


app.UseWhen(
   context => context.Request.Query.ContainsKey("keycloack"),
   appBuilder => appBuilder.Use(async (context, next) =>
   {
       await context.Response.WriteAsync("Se for true vai passar por aqui");
       await next(context);
   })
);

app.Run(async (context) =>
{
    await context.Response.WriteAsync("Middleware 4\n");

});



app.Run();
