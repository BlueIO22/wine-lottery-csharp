using Microsoft.EntityFrameworkCore;
using wine_lottery_csharp.Dal.Context;
using wine_lottery_csharp.Handlers;
using wine_lottery_csharp.Handlers.Interfaces;
using wine_lottery_csharp.Repository;
using wine_lottery_csharp.Repository.Helpers;
using wine_lottery_csharp.Repository.Interfaces;
using wine_lottery_csharp.services.interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<LotteryDbContext>(options => options.UseSqlServer(builder.Configuration["ConnectionStrings:AZURE_SQL_CONNECTIONSTRING"]));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Services
builder.Services.AddSingleton<IPaymentService, PaymentService>();

// Repositories
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<ILotteryRepository, LotteryRepository>();
builder.Services.AddScoped<IWineRepository, WineRepository>();

// Helpers
builder.Services.AddSingleton<ILotteryHelper, LotteryHelper>();

// Handlers
builder.Services.AddScoped<ICustomerHandler, CustomerHandler>();
builder.Services.AddScoped<ILotteryHandler, LotteryHandler>();
builder.Services.AddScoped<IPaymentHandler, PaymentHandler>();


var app = builder.Build();


app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
