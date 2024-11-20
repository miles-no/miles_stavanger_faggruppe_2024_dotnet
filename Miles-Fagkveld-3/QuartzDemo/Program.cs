
using Quartz;
using QuartzDemo;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddQuartz(options =>
{
    // Obsolete: default now
    //options.UseMicrosoftDependencyInjectionJobFactory();

    var jobKey = new JobKey(nameof(MyHostedService));
    options
        .AddJob<MyHostedService>(jobKey)
        .AddTrigger(trigger => 
            trigger
                .ForJob(jobKey)
                .WithSimpleSchedule(s => s.WithIntervalInSeconds(1).RepeatForever()));
});

builder.Services.AddQuartzHostedService(options =>
{
    options.WaitForJobsToComplete = true;
});

var host = builder.Build();
host.Run();
