namespace PaySmartly.Calculations.Endpoints
{
    static class PaySlipEndpoints
    {
        public static PaySlipEndpoint HealthEndpoint = new("health", "health", "GET");
        public static PaySlipEndpoint CreateEndpoint = new("calculations/pay-slips", "calculate-pay-slip", "POST");
    }
}