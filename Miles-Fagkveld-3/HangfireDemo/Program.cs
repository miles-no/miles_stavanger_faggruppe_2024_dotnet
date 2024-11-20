using Hangfire;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHangfire(configuration =>
    {
        configuration.UseSqlServerStorage(@"Data Source=.\SQLEXPRESS; Initial Catalog=HangfireTest; Integrated Security=True; Encrypt=False");

        var everyMinuteCron = "* * * * *";
        RecurringJob.AddOrUpdate<CountJob>(nameof(CountJob), job => job.Execute(), everyMinuteCron);
    }
);

builder.Services.AddHangfireServer();

var app = builder.Build();

app.MapGet("/enqueue", (IBackgroundJobClient backgroundJobClient) =>
{
    backgroundJobClient.Enqueue(() => Console.WriteLine("Enqueued"));
});

app.MapGet("/schedule", (IBackgroundJobClient backgroundJobClient) =>
{
    Console.WriteLine("Scheduled 2");
    backgroundJobClient.Schedule(() => Console.WriteLine("Scheduled"), TimeSpan.FromSeconds(0));
});

app.MapHangfireDashboard();

app.Run();
