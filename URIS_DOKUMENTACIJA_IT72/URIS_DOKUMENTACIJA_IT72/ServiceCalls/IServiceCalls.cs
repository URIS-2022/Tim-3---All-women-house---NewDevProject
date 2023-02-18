namespace URIS_DOKUMENTACIJA_IT72.ServiceCalls
{
    public interface IServiceCalls<T>
    {
        Task<T> SendGetRequestAsync(string url);
    }
}
