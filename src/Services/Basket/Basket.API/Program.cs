var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
var assembly = typeof(Program).Assembly;
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));

});

var app = builder.Build();

app.MapCarter();

//Configue the HTTP request pipeline.
app.MapGet("/", () => "Hello World!");

app.Run();
