namespace MoblieShared
{
    public class PublicClient
    {
        public HttpClient Client { get; set; }

        public PublicClient(HttpClient client)
        {
            Client = client;
        }
    }
}
