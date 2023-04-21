using Microsoft.EntityFrameworkCore;
using wine_lottery_csharp.Dal.Context;
using wine_lottery_csharp.Handlers;
using wine_lottery_csharp.Handlers.Interfaces;
using wine_lottery_csharp.services.interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<LotteryDbContext>(options => options.UseSqlServer(builder.Configuration["ConnectionStrings:AZURE_SQL_CONNECTIONSTRING"]));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IPaymentService, PaymentService>();
builder.Services.AddSingleton<IPaymentHandler, PaymentHandler>();

var app = builder.Build();


app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
