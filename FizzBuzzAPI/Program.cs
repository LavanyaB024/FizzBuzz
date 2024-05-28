using FizzBuzzAPI.Interfaces;
using FizzBuzzAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IFizzBuzzService, FizzBuzzService>();
builder.Services.AddTransient<IFizzBuzzServiceFactory, FizzBuzzServiceFactory>();
builder.Services.AddTransient<IFizzBuzzProcessor, FizzBuzzProcessor>();
builder.Services.AddTransient<IFizzBuzzValidator, FizzBuzzValidator>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


