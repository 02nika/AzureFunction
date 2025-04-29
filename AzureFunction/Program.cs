using AzureFunction.Interfaces;
using AzureFunction.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Inversion Principle: ყველა სერვისი დამატებულია ინჯექშენის და ინტერფეისების დახამრებით
builder.Services.AddScoped<IDiscountCalculator, PercentageDiscountCalculator>();
builder.Services.AddScoped<IDiscountCalculator, FixedDiscountCalculator>();
builder.Services.AddScoped<IInvoiceProcessor, InvoiceProcessor>();
builder.Services.AddScoped<ILoggerService, ConsoleLoggerService>();
    
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();