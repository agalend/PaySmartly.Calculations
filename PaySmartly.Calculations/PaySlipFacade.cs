using PaySmartly.Calculations.Entities;

namespace PaySmartly.Calculations
{
    public class PaySlipFacade(WebApplication app)
    {
        private readonly WebApplication app = app;

        public void RegisterCreatePaySlipMethod()
        {
            app.MapPost("/payslips", async (PaySlipRequest request, IPaySlipManager paySlipManager) =>
            {
                PaySlipRecordDto? paySlipRecordDto = await paySlipManager.CreatePaySlip(request);

                return paySlipRecordDto is null
                    ? Results.Problem()
                    : Results.Created($"/payslips/{paySlipRecordDto.Id}", paySlipRecordDto);
            });
        }

        public void RegisterGetPaySlipMethod()
        {
            app.MapGet("/payslips/{id}", async (string id, IPaySlipManager paySlipManager) =>
            {
                PaySlipRecordDto? paySlipRecordDto = await paySlipManager.GetPaySlip(id);

                return paySlipRecordDto is null
                    ? Results.NotFound()
                    : Results.Ok(paySlipRecordDto);

            });
        }

        public void RegisterDeletePaySlipMethod()
        {
            app.MapDelete("/payslips/{id}", async (string id, IPaySlipManager paySlipManager) =>
            {
                PaySlipRecordDto? paySlipRecordDto = await paySlipManager.DeletePaySlip(id);

                return paySlipRecordDto is null
                    ? Results.NotFound()
                    : Results.NoContent();

            });
        }

        public void Run()
        {
            app.Run();
        }
    }
}