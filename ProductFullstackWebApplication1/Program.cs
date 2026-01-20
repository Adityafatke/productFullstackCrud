using Microsoft.EntityFrameworkCore;
using ProductFullstackWebApplication1.Data;
using ProductFullstackWebApplication1.Repository.Definations;
using ProductFullstackWebApplication1.Repository.Implementation;
using ProductFullstackWebApplication1.Sevices.Definations;
using ProductFullstackWebApplication1.Sevices.Implementation;

var builder = WebApplication.CreateBuilder(args);

// ✅ Add CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173") // your React app URL
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// ✅ Add other services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ProductDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("Con")));

builder.Services.AddScoped<IproductRepository, ProductRepository>();
builder.Services.AddScoped<IproductService, ProductService>();

var app = builder.Build();

// ✅ Use CORS BEFORE other middlewares that handle requests
app.UseCors("AllowFrontend");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
