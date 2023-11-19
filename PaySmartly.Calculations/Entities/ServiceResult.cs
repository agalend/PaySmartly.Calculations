namespace PaySmartly.Calculations.Entities
{
    public record class ServiceResult<T>(T Result, ServiceIdentity ServiceIdentity);
}