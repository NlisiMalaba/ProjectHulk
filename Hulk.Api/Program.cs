using Hulk.Core.Helpers;
using Hulk.Core.Interfaces;
using Hulk.Core.Services;
using Hulk.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<HulkDbContext>(options => options.UseSqlServer(connectionString, o => o.UseCompatibilityLevel(120)));
builder.Services.AddCors();
builder.Services.AddControllers().AddJsonOptions(jsonOptions =>
{
    jsonOptions.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

builder.Services.AddScoped<IPairService, PairService>();
//builder.Services.AddScoped<IBrokerService, BrokerService>();
//builder.Services.AddScoped<ITradeLogService, TradeLogService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors(x => x
    .SetIsOriginAllowed(origin => true)
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());
app.UseMiddleware<ErrorHandlerMiddleware>();




app.Run();


