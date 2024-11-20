using Quartz;

namespace QuartzDemo
{
    [DisallowConcurrentExecution]
    internal class MyHostedService : IJob
    {
        private readonly ILogger<MyHostedService> _logger;

        public MyHostedService(ILogger<MyHostedService> logger)
        {
            _logger = logger;
        }

        public Task Execute(IJobExecutionContext context)
        {
            DoWork();

            return Task.CompletedTask;
        }

        private void DoWork()
        {
            _logger.LogInformation("Worker running at: {time}", DateTime.Now.ToString("O"));
        }
    }
}
