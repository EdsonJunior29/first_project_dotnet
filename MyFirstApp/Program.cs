using MyFirstApp.CustomMiddleware;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.Run();
