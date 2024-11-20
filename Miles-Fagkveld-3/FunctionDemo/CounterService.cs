using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FunctionDemo
{
    public class CounterService
    {
        private readonly ILogger _logger;

        public CounterService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<CounterService>();
        }

        [Function("Function1")]
        public void Run([TimerTrigger("0 * * * * *")] TimerInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            
            if (myTimer.ScheduleStatus is not null)
            {
                _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
            }
        }
    }
}
