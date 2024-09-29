using Api.Data;
using Api.Data.Repository;
using Api.Data.Repository.Contracts;
using Api.Mappings;
using Api.Service;
using Api.Service.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OpenTelemetry.Trace;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IProductsRepository,ProductsRepository>();
builder.Services.AddScoped<IProductService ,ProductService>();

builder.Services.AddScoped<ICartRepository,CartRepository>();
builder.Services.AddScoped<ICartItemsRepository,CartItemsRepository>();
builder.Services.AddScoped<ICartService,CartService>();

builder.Services.AddScoped<IOrdersRepository,OrdersRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();


builder.Services.AddScoped<IOTPService,OTPService>();

builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add support to logging with SERILOG
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddOpenTelemetry()
    .WithTracing(builder => builder
        .AddAspNetCoreInstrumentation()
        .AddHttpClientInstrumentation()
        .AddConsoleExporter());

// DB Connections
builder.Services.AddDbContext<InstantAppDbContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresDbConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

// Enable CORS
app.UseCors("AllowAllOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();
