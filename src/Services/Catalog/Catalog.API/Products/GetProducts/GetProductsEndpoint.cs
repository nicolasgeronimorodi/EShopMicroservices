
namespace Catalog.API.Products.GetProducts;

//public record GetProductsRequest();
// TODO: Can´t map GetProductsQuery to GetProductsRequest, because GetProductsQuery has no properties.

public record GetProductsResponse(IEnumerable<Product> Products); 
//TODO: Shouldn´t this be a list of ProductDto instead of Product? We don´t want to expose the internal Product entity directly in the API response.

public class GetProductsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async (ISender sender) =>
        {
            var result = await sender.Send(new GetProductsQuery());
            var response = result.Adapt<GetProductsResponse>();
            return Results.Ok(response);
        })
        .WithName("GetProducts")
        .Produces<GetProductsResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get products")
        .WithDescription("Get products");
    }
}
