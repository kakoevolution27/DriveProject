using Cloudflare.NET.Core;
using Cloudflare.NET.R2;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();

string? DbConnectionString = builder.Configuration.GetConnectionString("StringConexaoPostgres");

builder.Services.AddDbContext<DriveDbContext>(options => options.UseNpgsql(DbConnectionString));
builder.Services.Configure<R2Options>(builder.Configuration.GetSection("R2"));
builder.Services.AddScoped<IStorageService, R2StorageService>();
builder.Services.AddCloudflareApiClient(builder.Configuration);
builder.Services.AddCloudflareR2Client(builder.Configuration);
builder.Services.AddScoped<GenericRepository>();
builder.Services.AddScoped<GenericService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

