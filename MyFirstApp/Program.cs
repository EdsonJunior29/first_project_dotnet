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

    //Obter informações do request
    var method = context.Request.Method; // Método HTTP (GET, POST, etc.)

    /*Caminho da requisição (URL)
     * Ao executar a URL: http://localhost:5287/path
     * O path é essa parte da url em diante: /path
     */
    var path = context.Request.Path;

    /* String de consulta
     * http://localhost:5287/dashboard?user=123&filter=active
     * Nesse exemplo da Url acima a parte da query string é: ?user=123&filter=active
     */
    var queryString = context.Request.QueryString;

    /*Verificar se a queryString está na URL
     * Caso esteja apresenta True
     * Caso contrário apresenta False
     */
    var queryStringParameters = context.Request.Query.ContainsKey("user");

    // User-Agent do cliente
    /* ex: User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) 
     * Chrome/142.0.0.0 Safari/537.36
     */
    var userAgent = context.Request.Headers["User-Agent"].ToString(); 

    //Dado que será retorna na resposta da requisição
    await context.Response.WriteAsync("Hello, World!");
    await context.Response.WriteAsync($"\nRequest Method: {method}");
    await context.Response.WriteAsync($"\nRequest Path: {path}");
    await context.Response.WriteAsync($"\nQuery String: {queryString}");
    await context.Response.WriteAsync($"\nUser-Agent: {userAgent}");
    await context.Response.WriteAsync($"\nQuery String has 'user' parameter: {queryStringParameters}");


});

app.Run();
