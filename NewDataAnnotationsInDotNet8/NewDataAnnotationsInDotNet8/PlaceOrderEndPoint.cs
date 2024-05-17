using System.ComponentModel.DataAnnotations;

namespace NewDataAnnotationsInDotNet8
{
    public static class PlaceOrderEndPoint
    {
        public static void AddPlaceOrderEndPoint(this IEndpointRouteBuilder app)
        {

            var placeOrderEndPoint = app.MapGroup("api/v1");
            placeOrderEndPoint.PlaceOrdrEndPoint();
        }

        private static void PlaceOrdrEndPoint(this RouteGroupBuilder routeGroup)
        {
            routeGroup.MapPost("/placeorder", async (Item item) =>
            {
                var validationResults = new List<ValidationResult>();
                var validationContext = new ValidationContext(item, null, null);
                bool isValid = Validator.TryValidateObject(item, validationContext, validationResults, true);

                if (!isValid)
                {
                    return Results.BadRequest(validationResults);
                }
                // Place order logic
                return Results.Created("/order/1", item);
            })
            .WithName("PlaceOrder")
            .WithOpenApi();

        }
    }
}
