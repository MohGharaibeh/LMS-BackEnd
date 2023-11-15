
using LMS.Core.Common;
using LMS.Core.Repository;
using LMS.Core.Service;
using LMS.Infra.Common;
using LMS.Infra.Repository;
using LMS.Infra.Service;
using System.Configuration;

namespace LMS.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddScoped<IDbContext, DbContext>();

        builder.Services.AddScoped<IGetRepository, GetRepository>();
        builder.Services.AddScoped<IGetService, GetService>();

        builder.Services.AddScoped<IDeleteRepository, DeleteRepository>();
        builder.Services.AddScoped<IDeleteService, DeleteService>();

        builder.Services.AddScoped<IGetIdRepository, GetIdRepository>();
        builder.Services.AddScoped<IGetIdService, GetIdService>();

        builder.Services.AddScoped<ICreateRepository, CreateRepository>();
        builder.Services.AddScoped<ICreateService, CreateService>();

        builder.Services.AddScoped<IUpdateRepository, UpdateRepository>();
        builder.Services.AddScoped<IUpdateService, UpdateService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}