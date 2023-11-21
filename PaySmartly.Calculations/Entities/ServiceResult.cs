namespace PaySmartly.Calculations.Entities
{
    public record class ServiceResult<T>(T Value, ServiceIdentity ServiceIdentity);
}