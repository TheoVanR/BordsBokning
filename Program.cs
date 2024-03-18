using Application;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//SQLite
builder.Services.AddDbContext<BokningsContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => options.AddPolicy("BokningPolicy", builder =>
builder.AllowAnyOrigin() 
.AllowAnyMethod()
.AllowAnyHeader()));
var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();



app.UseAuthorization();
app.UseCors("BokningPolicy");
app.MapControllers().RequireCors("BokningPolicy");

app.MapControllers();

app.Run();
