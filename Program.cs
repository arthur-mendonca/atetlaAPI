
using AtetlaAPI.endpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "Olá, mundo filho da puta!");

app.MapGet("/teste", () => "1, 2, 3... testanto essa porra!");

app.MapGet("/teste2", () => "4, 5, 6... testanto essa porra!");

app.AdicionarAtletaEndpoint();


app.Run();


