using WorkerServiceApp;
using Microsoft.EntityFrameworkCore;


var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddDbContext<context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
