namespace PaySmartly.Calculations.Filters
{
    public class DeletePaySlipValidator : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var id = context.GetArgument<string>(0);

            if (string.IsNullOrEmpty(id))
            {
                Results.BadRequest($"Invalid {nameof(id)} value, you should provide a valid non empty string value");
            }

            return await next(context);
        }
    }
}