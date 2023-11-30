namespace PaySmartly.Calculations.Endpoints
{
    static class PaySlipEndpoints
    {
        public static PaySlipEndpoint CreateEndpoint = new("/pay-slips", "create-pay-slip", "POST");
    }
}