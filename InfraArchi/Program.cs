using InfraArchi;

var builder = WebApplication.CreateBuilder(args);

Startup.ConfigureServices(builder.Services);

var app = builder.Build();

Startup.ConfigureApp(app);

app.Run();
