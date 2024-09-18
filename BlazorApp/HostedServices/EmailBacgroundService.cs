using BlazorApp.Data;

namespace BlazorApp.HostedServices
{
    public class EmailsHostedService : IHostedService, IDisposable
    {
        private int executionCount = 0;
        private readonly ILogger<EmailsHostedService> _logger;
        private readonly IServiceScopeFactory serviceScope;
        private Timer? _timer = null;

        public EmailsHostedService(ILogger<EmailsHostedService> logger, IServiceScopeFactory serviceScope)
        {
            _logger = logger;
            this.serviceScope = serviceScope;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(10));

            return Task.CompletedTask;
        }

        private void DoWork(object? state)
        {
            using (var scope = serviceScope.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<PeopleDbContext>();

                var emails_to_process = db.Emails.Where(x => x.Processed == null);

                foreach (var email in emails_to_process)
                {
                    email.Processed = DateTime.Now;
                }

                var processed = db.SaveChanges();
                _logger.LogInformation(
                $"Odeslal jsem {processed} emailů");
            }



            var count = Interlocked.Increment(ref executionCount);

            _logger.LogInformation(
                "Timed Hosted Service is working. Count: {Count}", count);
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
