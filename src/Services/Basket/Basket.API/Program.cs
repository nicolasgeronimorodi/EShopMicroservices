var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
var app = builder.Build();

//Configue the HTTP request pipeline.
app.MapGet("/", () => "Hello World!");

app.Run();
