using ParrotIncSquawk;
using ParrotIncSquawk.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

#region Add services to the container.
builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices()
    .AddApiServices();
#endregion

var app = builder.Build();

#region Configure the HTTP request pipeline.
app.UseApplicationServices();
app.Run();
#endregion