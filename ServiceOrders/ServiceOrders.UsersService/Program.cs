using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ServiceOrders.Models.Interfaces;
using ServiceOrders.Repository;
using ServiceOrders.Repository.Repository;
using ServiceOrders.UsersService;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddScoped<IUsersService, UsersService>();
    builder.Services.AddScoped<IUsersRepository, UsersRepository>();

    builder.Services.AddLogging(loggingBuilder =>
    {
        loggingBuilder.AddConsole();
        loggingBuilder.AddDebug();
    });

    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<ServiceOrdersDbContext>(options => options
        .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


    builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Users service API",
            Version = "v1",
            Description = "Service for users management"
        });
    });
}

var app = builder.Build();
{
    app.MapControllers();

    app.UseRewriter(new RewriteOptions().AddRedirect("^$", "swagger"));

    app.UseStaticFiles(new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(
      Path.Combine(Directory.GetCurrentDirectory(), "OpenApi")),
        RequestPath = "/specification"
    });

    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/specification/index.json", "Specification"));

    app.Run();
}

