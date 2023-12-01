namespace PaySmartly.Calculations.Endpoints
{
    static class PaySlipEndpoints
    {
        public static PaySlipEndpoint CreateEndpoint = new("calculations/pay-slips", "calculate-pay-slip", "POST");
    }
}