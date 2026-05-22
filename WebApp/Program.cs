using System.Reflection;
using WebApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.MapGet("/version", () =>
{
    var assembly = Assembly.GetExecutingAssembly();
    var name = assembly.GetName();

    var version = name.Version?.ToString() ?? "unknown";
    var informationalVersion =
        assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion
        ?? version;

    return Results.Ok(new
    {
        Application = name.Name,
        Version = version,
        InformationalVersion = informationalVersion,
        Environment = app.Environment.EnvironmentName
    });
});

app.MapGet("/hello", () => "Hello World!");

app.Run();
