﻿using InfraArchi.Models;

namespace InfraArchi;

public static class Startup
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddLogging();
        services.AddDbContext<TodoDbContext>();
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddHealthChecks();
        services.AddCors(options => options.AddDefaultPolicy(builder => builder.AllowAnyOrigin()));
    }

    public static void ConfigureApp(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        } 
        app.UseSwagger(); 
        app.UseSwaggerUI();

        app.MapControllers();
        app.MapHealthChecks("/healthz");

        app.UseCors();
        
        using var context = app.Services.CreateScope().ServiceProvider.GetService<TodoDbContext>();
        context?.Database.EnsureCreated();
    }
}