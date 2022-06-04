using Microsoft.EntityFrameworkCore;
using WebApiSummeryHW.Data;
using WebApiSummeryHW.Repos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options=> options.UseSqlServer(builder.Configuration.GetConnectionString("Dev")));
builder.Services.AddTransient<IFlowersRepo,FlowersRepo>();
builder.Services.AddCors(options => options.AddDefaultPolicy( x =>
 {
     x.AllowAnyOrigin().AllowAnyMethod();
 }));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors();  
app.MapControllers();

app.Run();
