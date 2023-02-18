namespace Registration_projekat.ServiceCalls
{
    public interface IServiceCalls<T>
    {
        Task<T> SendGetRequestAsync(string url);
    }
}
