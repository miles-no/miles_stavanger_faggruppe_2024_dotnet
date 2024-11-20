using HostedServiceDemo;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.Configure<HostOptions>(x => x.ServicesStartConcurrently = true);

builder.Services.AddHostedService<MyBackgroundService>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
