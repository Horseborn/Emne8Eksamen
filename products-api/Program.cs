using Microsoft.EntityFrameworkCore;
using products_api.Data;
using products_api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddDbContext<ProductsDbContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), 
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection")));
}); 

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {    
    app.MapOpenApi();
// }

app.MapProductsEndpoints();
app.UseHttpsRedirection();
app.Run();
