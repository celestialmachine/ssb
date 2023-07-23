using Microsoft.EntityFrameworkCore;
using ssb_api.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddDbContext<BudgetContext>(opt => opt.UseInMemoryDatabase("SSBudget")); di for in-memory db

//Add EF Core DI
builder.Services.AddDbContext<BudgetContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("BudgetContext")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//TODO remove when API is in production
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularOrigins", builder =>
    {
        builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

//TODO remove when API is in productions
app.UseCors("AllowAngularOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();
