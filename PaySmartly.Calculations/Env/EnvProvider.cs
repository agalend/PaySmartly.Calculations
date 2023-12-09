namespace PaySmartly.Calculations.Env
{
    public interface IEnvProvider
    {
        string? GetPersistanceClientUrl();
        string? GetLegislationClientUrl();
    }

    public class EnvProvider(GrpcClients? grpcClients) : IEnvProvider
    {
        private const string PERSISTANCE_URL = "PERSISTANCE_URL";
        private const string LEGISLATION_URL = "LEGISLATION_URL";

        private readonly string? defaultPersistanceUrl = grpcClients?.Persistance?.Url;
        private readonly string? defaultLegislationUrl = grpcClients?.Legislation?.Url;

        public string? GetLegislationClientUrl()
        {
            string? url = Environment.GetEnvironmentVariable(LEGISLATION_URL);
            url ??= defaultLegislationUrl;

            return url;
        }

        public string? GetPersistanceClientUrl()
        {
            string? url = Environment.GetEnvironmentVariable(PERSISTANCE_URL);
            url ??= defaultPersistanceUrl;

            return url;
        }
    }
}