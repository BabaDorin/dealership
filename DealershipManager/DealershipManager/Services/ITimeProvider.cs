namespace DealershipManager.Services
{
    public interface ITimeProvider
    {
        public DateTime UtcNow { get; }
    }
}
