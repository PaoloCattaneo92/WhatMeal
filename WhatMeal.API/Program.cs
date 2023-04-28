using Serilog;
using WhatMeal.API;
using WhatMeal.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("log.txt")
    .CreateLogger();
Log.Logger = logger;

var source = builder.Configuration.GetSection("Data").Get<DataSettings>()?.Source ?? DataSettings.DEFAULT_SOURCE;
JsonMealRepository.Instance = new JsonMealRepository(source);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

new VersionEPMapper().Map(app);
new DishEPMapper().Map(app);

app.Run();