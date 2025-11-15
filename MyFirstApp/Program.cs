var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


/*Nesse exemplo estamos especificando middleware separados
 * A aplicação irá executar um por vez.
 */
app.Run(async (HttpContext context) => {
    await context.Response.WriteAsync("Middleware 1");
});

app.Run(async (HttpContext context) => {
    await context.Response.WriteAsync("Middleware 2");
});

//***********************************************

/*Nesse exeplo já estamos utilizando middleware sequenciais.
 * Podendo ter diversos middleware.
 * 
 * 
 * Nesse exemplo foi criado 2 middleware
 * que serão executados em sequência.
 * OBS: O context recebido pelo 1º middleware
 * e passado para o segundo no método nex(context).
 * 
 * OBS2:O método next(context) representa a aplicação
 * que existe outro middleware em sequencia para ser executado.
 */
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Middleware 1");
    await next(context);
});

app.Run(async (HttpContext context) => {
    await context.Response.WriteAsync("Middleware 2");
});

app.Run();
