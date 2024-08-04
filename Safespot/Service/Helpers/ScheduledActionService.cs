using Safespot.Data;

public class ScheduledActionService : IHostedService, IDisposable
{
    private Timer _timer;
    private readonly IServiceProvider _serviceProvider;

    public ScheduledActionService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMinutes(1)); // Run every minute
        return Task.CompletedTask;
    }

    private void DoWork(object state)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<SafespotDbContext>();

            // Example: Perform an action at a specific time
            var currentTime = DateTimeOffset.Now;
            var targetTime = new DateTimeOffset(currentTime.Year, currentTime.Month, currentTime.Day, 15, 0, 0, currentTime.Offset); // 3:00 PM

            if (currentTime >= targetTime && currentTime < targetTime.AddMinutes(1))
            {
                // Action to perform at 3:00 PM
                PerformScheduledAction(context);
            }
        }
    }

    private void PerformScheduledAction(SafespotDbContext context)
    {
        // Your scheduled action logic here
        // Example: Update a database table or send notifications
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}
