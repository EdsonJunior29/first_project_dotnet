var builder = WebApplication.CreateBuilder(args);

//Adiciona todas as controllers no service container
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
