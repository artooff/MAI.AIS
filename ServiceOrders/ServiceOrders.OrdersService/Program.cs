using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using ServiceOrders.Models.Interfaces;
using ServiceOrders.OrdersService.Clients;
using ServiceOrders.OrdersService.Services;
using ServiceOrders.Repository;
using ServiceOrders.Repository.Repositories;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddScoped<IOrdersService, OrdersService>();
    builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();

    var configuration = builder.Configuration;

    var connectionString = configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<ServiceOrdersDbContext>(options => options
        .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

    builder.Services.AddHttpClient<UsersClient>(client =>
    {
        client.BaseAddress = new Uri(configuration["USERS_API_BASE_URL"]);
    });
    builder.Services.AddHttpClient<ServicesClient>(client =>
    {
        client.BaseAddress = new Uri(configuration["SERVICES_API_BASE_URL"]);
    });

    builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Orders service API",
            Version = "v1",
            Description = "Service for orders management"
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
