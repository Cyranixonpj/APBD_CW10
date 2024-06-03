using Cwiczenia10.Contexts;
using Cwiczenia10.Exceptions;
using Cwiczenia10.RequestModels;
using Cwiczenia10.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataBaseContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
builder.Services.AddScoped<IAccountsService, AccountsService>();
builder.Services.AddScoped<IProductService, ProductService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapGet("api/accounts/{accountId:int}", async (int accountId,IAccountsService service) =>
{

    try
    {
        return Results.Ok(await service.GetAccountByIdAsync(accountId));
    }
    catch (NotFoundException e)
    {
        return Results.NotFound(e.Message);
    }
});
app.MapPost("/api/products", async (AddProductRequestModel productModel, IProductService service) =>
{
    try
    {
        return Results.Ok(await service.AddProductAsync(productModel));
    }
    catch (BadRequestException e)
    {
        return Results.BadRequest(e.Message);
    }
});


app.Run();

