namespace URIS_BiddingProcess_it24.ServicesCalls
{
    public interface IServiceCall<T>
    {
        Task<T> SendGetRequestAsync(string url);
    }
}
