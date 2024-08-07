using Safespot.Data.IRepositories;
using Safespot.Models.Entities;

public class ScheduledActionService : IHostedService, IDisposable
{
    private Timer _timer;
    private readonly IServiceProvider _serviceProvider;
    private readonly IRepository<Slot> _repository;

    public ScheduledActionService(
        IServiceProvider serviceProvider,
        IRepository<Slot> repository)
    {
        _serviceProvider = serviceProvider;
        this._repository = repository;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMinutes(1)); // Run every minute
        return Task.CompletedTask;
    }

    private async void DoWork(object slotId)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            //var context = scope.ServiceProvider.GetRequiredService<SafespotDbContext>();

            // Example: Perform an action at a specific time
            var currentTime = DateTimeOffset.Now;
            var targetTime = new DateTimeOffset(currentTime.Year, currentTime.Month, currentTime.Day, 15, 0, 0, currentTime.Offset); // 3:00 PM

            if (currentTime >= targetTime && currentTime < targetTime.AddMinutes(1))
            {
                // Action to perform at 3:00 PM
                await PerformScheduledAction((Guid)slotId);
            }
        }
    }

    private async Task PerformScheduledAction(Guid id)
    {
        // Your scheduled action logic here
        // Example: Update a database table or send notifications
        var dbSlot = await this._repository.SelectAsync(p => p.Id == id);
        dbSlot.IsAvailableForBooking = false;
        this._repository.Update(dbSlot);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
        GC.SuppressFinalize(this);
    }
}
