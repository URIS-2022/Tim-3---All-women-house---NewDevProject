namespace URIS_Licitacion_IT67_2019.CallServices
{
    public interface IServiceCall<T>
    {
        Task<T> SendGetRequest(string url);
    }
}
