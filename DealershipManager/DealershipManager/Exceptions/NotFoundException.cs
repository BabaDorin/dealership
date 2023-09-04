namespace DealershipManager.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(Guid entryId)
            : base($"Could not find any entry with the following id: {entryId}")
        {
        }
    }
}
