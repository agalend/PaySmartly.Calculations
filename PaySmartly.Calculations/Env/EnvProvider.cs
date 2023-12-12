namespace PaySmartly.Calculations.Env
{
    public interface IEnvProvider
    {
        string? GetPersistenceClientUrl();
        string? GetLegislationClientUrl();
    }

    public class EnvProvider(GrpcClients? grpcClients) : IEnvProvider
    {
        private const string PERSISTENCE_URL = "PERSISTENCE_URL";
        private const string LEGISLATION_URL = "LEGISLATION_URL";

        private readonly string? defaultPersistanceUrl = grpcClients?.Persistence?.Url;
        private readonly string? defaultLegislationUrl = grpcClients?.Legislation?.Url;

        public string? GetLegislationClientUrl()
        {
            string? url = Environment.GetEnvironmentVariable(LEGISLATION_URL);
            url ??= defaultLegislationUrl;

            return url;
        }

        public string? GetPersistenceClientUrl()
        {
            string? url = Environment.GetEnvironmentVariable(PERSISTENCE_URL);
            url ??= defaultPersistanceUrl;

            return url;
        }
    }
}