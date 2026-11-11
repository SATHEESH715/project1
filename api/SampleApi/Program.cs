var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// The Angular build is copied into wwwroot at deploy time, so one App Service serves both the page and the API.
app.UseDefaultFiles();
app.UseStaticFiles();

app.MapGet("/api/properties", () => PropertyData.GetAll());
app.MapGet("/api/health", () => Results.Ok(new { status = "ok" }));

app.Run();

public record PropertyItem(Guid Id, int PropertyNumber, string Address, string Status);

public static class PropertyData
{
    public static IReadOnlyList<PropertyItem> GetAll() =>
    [
        new(Guid.Parse("11111111-1111-1111-1111-111111111111"), 1001, "1 High Street, Leeds", "Occupied"),
        new(Guid.Parse("22222222-2222-2222-2222-222222222222"), 1002, "2 Mill Lane, York", "Void"),
        new(Guid.Parse("33333333-3333-3333-3333-333333333333"), 1003, "3 Park Road, Hull", "Occupied"),
    ];
}
