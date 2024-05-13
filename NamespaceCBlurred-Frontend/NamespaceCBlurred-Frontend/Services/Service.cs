namespace NamespaceCBlurred_Frontend.Services
{
    public class Service
    {
        public SoundService SoundService { get; }
        public CreationService CreationService { get; }

        private readonly string apiBaseUrl = "https://localhost:7155/api/";
        private static readonly Service Instance = new ();

        private Service()
        {
            SoundService = new (apiBaseUrl);
            CreationService = new (apiBaseUrl);
        }

        public static Service GetInstance()
        {
            return Instance;
        }
    }
}
