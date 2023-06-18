using Microsoft.EntityFrameworkCore;
using PlatformService.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseInMemoryDatabase("InMem"));

builder.Services.AddScoped<IPlatformRepository, PlatformRepository>();

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

PreporationDb.PrepPopulation(app);

app.Run();