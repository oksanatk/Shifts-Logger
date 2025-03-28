using Microsoft.EntityFrameworkCore;
using ShiftsLogger.WebApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<WorkerShiftContext>();

var app = builder.Build();

app.MapOpenApi();
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Shifts Logger v1 API");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
